using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class StatsEditor
{

    [HideInInspector] public CharacterStats stats;

    public int hp;
    public int armor;
    public int restistance;

    [SerializeField] private IntegerField hpInput;
    [SerializeField] private IntegerField armorInput;
    [SerializeField] private IntegerField resistanceInput;
    
    public StatsEditor(VisualElement visualElement) {
    
        hpInput = visualElement.Q<IntegerField>("HpInput");
        armorInput = visualElement.Q<IntegerField>("ArmorInput");
        resistanceInput = visualElement.Q<IntegerField>("ResistanceInput");

        hpInput.RegisterValueChangedCallback((v)=>stats.hp = v.newValue);
        armorInput.RegisterValueChangedCallback((v)=>stats.armor= v.newValue);
        resistanceInput.RegisterValueChangedCallback((v)=>stats.resistance = v.newValue);
    }
    
   public void Fill(CharacterStats stats) {
       this.stats = stats;
       hpInput.value = stats.hp;
       armorInput.value = stats.armor;
       resistanceInput.value = stats.resistance;
   }


    public interface IComponentEditorField {

        public void Fill();
        public void Read();
    }

    public class ComponentEditorStringField : IComponentEditorField {
        TextField textField;
        public Action<string> getter;
        public Func<string> setter;

        public ComponentEditorStringField(VisualElement rootVisualElement, string visualElementName, Action<string> getter, Func<string> setter) {
            textField = rootVisualElement.Q<TextField>(visualElementName);
            this.getter = getter;
            this.setter = setter;
        }

        public void Fill() {
            textField.value = setter.Invoke();
        }

        public void Read() {
            getter.Invoke(textField.value);
        }
    }
    public class ComponentEditorIntField : IComponentEditorField {
        IntegerField textField;
        public Action<int> getter;
        public Func<int> setter;

        public ComponentEditorIntField(VisualElement rootVisualElement, string visualElementName, Action<int> getter, Func<int> setter) {
            textField = rootVisualElement.Q<IntegerField>(visualElementName);
            this.getter = getter;
            this.setter = setter;
        }

        public void Fill() {
            textField.value = setter.Invoke();
        }

        public void Read() {
            getter.Invoke(textField.value);
        }
    }
}
