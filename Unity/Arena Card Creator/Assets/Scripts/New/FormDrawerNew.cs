using TMPro;

public class FormDrawerNew : CharacterComponentDrawerNew<Form> {

    public TextMeshProUGUI nameField;
    public TextMeshProUGUI bountyField;
    public StatsDrawerNew statsField;

    public override void Draw(Form component) {
        nameField.text = component.Name;
        bountyField.text = component.Bounty.ToString();
        statsField.Draw(component.Stats); 
    }
}
