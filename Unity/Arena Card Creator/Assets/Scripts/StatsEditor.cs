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
    
   public void fill(CharacterStats stats) {
       this.stats = stats;
       hpInput.value = stats.hp;
       armorInput.value = stats.armor;
       resistanceInput.value = stats.resistance;
   }
}
