using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene : CharacterComponent
{
    public CharacterStats Stats;
    public string Description;

    public Gene(Gene gene) {
        base.CopyBaseValues(gene);
        Stats = gene.Stats;
        Description = gene.Description;
    }
    public Gene() {}

    public override object Clone() {
        return new Gene(this);
    }
}
