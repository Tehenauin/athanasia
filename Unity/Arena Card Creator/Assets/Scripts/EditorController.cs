using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EditorController : MonoBehaviour {
    private VisualElement root;
    private Button editSelectedButton;
    private Button newFromSelectedButton;
    Dictionary<Type, Button> newComponentButtons =  new Dictionary<Type, Button>();

    private FormEditor formEditor;

    private void Start() {
        root = GetComponent<UIDocument>().rootVisualElement;
        editSelectedButton = root.Q<Button>("EditSelectedButton");
        newFromSelectedButton = root.Q<Button>("NewFromSelectedButton");
        newComponentButtons[typeof(Form)] = root.Q<Button>("NewFormButton");
        newComponentButtons[typeof(Gene)] = root.Q<Button>("NewGeneButton");
        newComponentButtons[typeof(CClass)] = root.Q<Button>("NewClassButton");
        newComponentButtons[typeof(Ability)] = root.Q<Button>("NewAbilityButton");
        formEditor = new FormEditor(root.Q<VisualElement>("FormEditor"));
        CharacterComponentDrawer.ComponentSelect.AddListener(OnComponentSelect);
    }

    private void OnComponentSelect(CharacterComponent c) {
        switch (c) {
            case Form form:
                formEditor.UpdateComponent(form);
                break;
            default:
                break;
        }
    }
}
