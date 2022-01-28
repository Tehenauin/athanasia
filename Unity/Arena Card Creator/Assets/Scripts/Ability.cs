using UnityEngine;

public class Ability :  CharacterComponent
{
    public int TickCost = 0;
    public string Description;

    public override object Clone() {
        throw new System.NotImplementedException();
    }
}
