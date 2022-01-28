using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
public class FormEditor : ComponentEditor<Form> {
    [SerializeField] private StatsEditor statsEditor;

    public FormEditor(VisualElement visualElement) {
        RegisterBaseFields(visualElement);
        statsEditor = new StatsEditor(visualElement.Q<VisualElement>("StatsEditor"));
        ClearAllFields();
    }

    protected override void Save() {
        Component.BaseStats = statsEditor.stats;
        nameInput.focusable = false;
        CharacterComponentLoader.SaveComponent(Component);
    }

    protected override void FillCustomFields() {
        statsEditor.fill(base.Component.BaseStats);
    }
    protected override void ClearCustomFields() {
        statsEditor.fill(CharacterStats.defaultStats);
    }
}

/*
public class FormEditorOld
{
    [HideInInspector][SerializeField] private Form Form;

    private VisualElement visualElement;

    [SerializeField] private TextField nameInput;
    [SerializeField] private IntegerField bountyInput;
    [SerializeField] private StatsEditor statsEditor;
    [SerializeField] private Button saveButton;

    public FormEditor(VisualElement visualElement) {
        this.visualElement = visualElement;
        nameInput = visualElement.Q<TextField>("NameInput");
        bountyInput = visualElement.Q<IntegerField>("BountyInput");
        statsEditor = new StatsEditor(visualElement.Q<VisualElement>("StatsEditor"));
        saveButton = visualElement.Q<Button>("SaveButton");

        ClearAllFields();

        nameInput.RegisterValueChangedCallback((v) => Form.Name = v.newValue);
        bountyInput.RegisterValueChangedCallback((v) => Form.Bounty = v.newValue);
        saveButton.RegisterCallback<ClickEvent>((v) => Save());
    }


    public void UpdateForm(Form form) {

        if (form == null) ClearAllFields();
        else {
            FillAllFields(form);
        }
    }

    void Save() {
        Form.BaseStats = statsEditor.stats;
        nameInput.focusable = false;
        CharacterComponentLoader.SaveComponent(Form);
    }

    void FillAllFields(Form form) {
        Form = new Form(form);
        nameInput.value = form.Name;
        bountyInput.value = form.Bounty;
        statsEditor.fill(form.BaseStats);
        nameInput.focusable = false;
    }

    void ClearAllFields() {
        Form = new Form();
        nameInput.value = "";
        bountyInput.value = 0;
        statsEditor.fill(CharacterStats.defaultStats);
        nameInput.focusable = true;
    }
    

}
*/