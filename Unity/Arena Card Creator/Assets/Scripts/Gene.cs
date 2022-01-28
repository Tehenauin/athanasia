using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene : CharacterComponent
{
    public CharacterStats stats;
    public string description;

    public Gene(Gene gene) {
        base.CopyBaseValues(gene);
        stats = gene.stats;
        description = gene.description;
    }
    public Gene() {}

    public override object Clone() {
        return new Gene(this);
    }
}
