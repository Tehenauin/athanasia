using UnityEngine;
using TMPro;

public class StatsDrawerNew : MonoBehaviour
{
    public TextMeshProUGUI hpField;
    public TextMeshProUGUI armorField;
    public TextMeshProUGUI resistanceField;

    public void Draw(CharacterStats stats) {
        hpField.text = stats.hp.ToString();
        armorField.text = stats.armor.ToString();
        resistanceField.text = stats.resistance.ToString();
    }
}
