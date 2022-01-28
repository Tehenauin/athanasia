using System.Collections.Generic;


[System.Serializable]
public struct CharacterStats {
    public int hp;
    public int armor;
    public int resistance;

    public static CharacterStats defaultStats => new CharacterStats {
        hp = 0,
        armor = 0,
        resistance = 0
    };

    public override string ToString() {
        return ($"HP: {hp}, Arm: {armor}, Res: {resistance}");
    }

}
