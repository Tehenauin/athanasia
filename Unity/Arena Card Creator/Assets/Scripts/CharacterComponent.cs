using System;

public abstract class CharacterComponent : ICloneable
{
    public string Name;
    public int Bounty = 0;

    public abstract object Clone();

    protected void CopyBaseValues(CharacterComponent cc) {
        Name = cc.Name;
        Bounty = cc.Bounty;
    }
}
