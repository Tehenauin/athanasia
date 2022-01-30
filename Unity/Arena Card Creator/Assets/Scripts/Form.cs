using System.Collections.Generic;
using UnityEngine;
using YamlDotNet;

[System.Serializable]
public class Form : CharacterComponent{
    [SerializeField] public CharacterStats Stats;
    public Form(Form form) {
        base.CopyBaseValues(form);
        Stats = form.Stats;
    }
    public Form() { }

    public override object Clone() {
        return new Form(this);
    }
}
