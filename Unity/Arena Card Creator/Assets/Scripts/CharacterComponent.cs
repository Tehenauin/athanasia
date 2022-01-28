public abstract class CharacterComponent
{
    public string Name;
    public int Bounty = 0;

    protected void CopyBaseValues(CharacterComponent cc) {
        Name = cc.Name;
        Bounty = cc.Bounty;
    }
}
