using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CClass : CharacterComponent {
    public CharacterStats Stats;
    public string Description;

    public CClass(CClass cClass) {
        base.CopyBaseValues(cClass);
        Stats = cClass.Stats;
        Description = cClass.Description;
    }
    public CClass() { }

    public override object Clone() {
        return new CClass(this);
    }
}
