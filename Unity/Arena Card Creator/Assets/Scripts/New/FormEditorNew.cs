using TMPro;

public class FormEditorNew : CharacterComponentEditorNew<Form> {

    public TMP_InputField nameField;
    public TMP_InputField bountyField;
    public StatsEditorNew statsField;

    public override void Draw(Form component) {
        nameField.text = component.Name;
        bountyField.text = component.Bounty.ToString();
        statsField.Draw(component.Stats);
    }
    public override Form Read() {
        return new Form {
            Name = nameField.text,
            Bounty = int.Parse(bountyField.text),
            Stats = statsField.Read()
        };
    }
}
