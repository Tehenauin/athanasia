using UnityEngine;

public class Ability :  CharacterComponent
{
    public int TickCost = 0; 
    public CharacterStats Stats;
    public string Description;

    public Ability(Ability ability) {
        base.CopyBaseValues(ability);
        TickCost = ability.TickCost;
        Stats = ability.Stats;
        Description = ability.Description;
    }
    public Ability() { }

    public override object Clone() {
        return new Ability(this);
    }
}
