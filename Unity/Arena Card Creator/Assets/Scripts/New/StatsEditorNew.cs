using UnityEngine;
using TMPro;

public class StatsEditorNew : MonoBehaviour
{
    [SerializeField] private TMP_InputField hpField;
    [SerializeField] private TMP_InputField armorField;
    [SerializeField] private TMP_InputField resistanceField;
    public void Draw(CharacterStats stats) {
        hpField.text = stats.hp.ToString();
        armorField.text = stats.armor.ToString();
        resistanceField.text = stats.armor.ToString();
    }

    public CharacterStats Read() {
        return new CharacterStats {
            hp = int.Parse(hpField.text),
            armor = int.Parse(armorField.text),
            resistance = int.Parse(resistanceField.text)
        };
    }
}
