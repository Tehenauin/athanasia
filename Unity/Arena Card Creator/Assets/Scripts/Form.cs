using System.Collections.Generic;
using UnityEngine;
using YamlDotNet;

[System.Serializable]
public class Form : CharacterComponent{
    [SerializeField] public CharacterStats BaseStats;
    public Form(Form form) {
        base.CopyBaseValues(form);
        BaseStats = form.BaseStats;
    }
    public Form() { }

    public override object Clone() {
        return new Form(this);
    }
}
