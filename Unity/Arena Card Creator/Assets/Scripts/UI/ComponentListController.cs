using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ComponentListController : MonoBehaviour {
    private VisualElement root;
    private VisualElement content;
    private DropdownField componentTypeDropdown;

    public VisualTreeAsset formTemplate;
    public VisualTreeAsset geneTemplate;
    public VisualTreeAsset cClassTemplate;
    public VisualTreeAsset abilityTemplate;

    public List<CharacterComponentDrawer> drawers = new List<CharacterComponentDrawer>();
    public Dictionary<Type, List<CharacterComponentDrawer>> ComponentDrawerRecyclePile = new Dictionary<Type, List<CharacterComponentDrawer>>();
    public Dictionary<string, Type> componentTypesDict = new Dictionary<string, Type> {
        ["Form"] =    typeof(Form),  
        ["Gene"] =    typeof(Gene),
        ["Class"] =   typeof(CClass),
        ["Ability"] = typeof(Ability)
    };

    private void Awake() {
        ComponentDrawerRecyclePile[typeof(Form)] = new List<CharacterComponentDrawer>();
        ComponentDrawerRecyclePile[typeof(Gene)] = new List<CharacterComponentDrawer>();
        ComponentDrawerRecyclePile[typeof(CClass)] = new List<CharacterComponentDrawer>();
        ComponentDrawerRecyclePile[typeof(Ability)] = new List<CharacterComponentDrawer>();
    }

    void Start() {
        root = GetComponent<UIDocument>().rootVisualElement;
        content = root.Q<ScrollView>("ScrollView").contentContainer;
        componentTypeDropdown = root.Q<DropdownField>("ComponentTypeDropdown");

        componentTypeDropdown.choices = new List<string>(componentTypesDict.Keys);
        componentTypeDropdown.RegisterValueChangedCallback(OnComponentTypeDropdownValueChange);
        componentTypeDropdown.value = componentTypeDropdown.choices[0];

        CharacterComponentLoader.LoadComponents();
        Refresh();
        CharacterComponentDrawer.ComponentSelect.AddListener(c => Debug.Log("selecting " + c.Name));
        CharacterComponentLoader.ComponentsUpdated.AddListener(Refresh);
    }

    void OnComponentTypeDropdownValueChange(ChangeEvent<string> evt) {
        FilterByType(componentTypesDict[evt.newValue]);
    }


    void FilterByType(Type type) {
        foreach (CharacterComponentDrawer drawer in drawers) {
            drawer.VisualElement.visible = drawer.ComponentType == type;
        }
    }


    public void Refresh() {
        DisposeAll();
        AddToList(CharacterComponentLoader.Components);
    }

    public void AddToList(List<CharacterComponent> components) {
        foreach (var c in components) {
            CreateOrRecycleDrawer(c);
        }
    }

    void DisposeAll() {
        foreach (var drawer in drawers) {
            ComponentDrawerRecyclePile[drawer.ComponentType].Add(drawer);
            drawer.VisualElement.visible = false;
        }
        drawers.Clear();
    }

    CharacterComponentDrawer CreateOrRecycleDrawer(CharacterComponent component) {
        var cPile = ComponentDrawerRecyclePile[component.GetType()];
        if (cPile.Count > 0) {
            CharacterComponentDrawer drawer = cPile[0];
            drawer.Update(component);
            drawer.VisualElement.visible = true;

            ComponentDrawerRecyclePile[component.GetType()].RemoveAt(0);
            drawers.Add(drawer);
            return drawer;
        } else {
            return CreateDrawer(component);
        }
    }

    CharacterComponentDrawer CreateDrawer(CharacterComponent component) {

        CharacterComponentDrawer d;

        switch (component) {
            case Form c:
                d = new FormDrawer(formTemplate, c);
                break;
            case Gene c:
                d = new GeneDrawer(formTemplate, c);
                break;
            case CClass c:
                d = new CClassDrawer(formTemplate, c);
                break;
            case Ability c:
                d = new AbilityDrawer(formTemplate, c);
                break;
            default:
                Debug.Log("invalid type!");
                return null;
        }
        content.Add(d.VisualElement);
        drawers.Add(d);
        return d;
    }
}
