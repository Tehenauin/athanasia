using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
public abstract class ComponentEditor<T> where T : CharacterComponent, new() {
    [HideInInspector] [SerializeField] protected T Component;

    protected VisualElement visualElement;

    [SerializeField] protected TextField nameInput;
    [SerializeField] protected IntegerField bountyInput;
    [SerializeField] protected Button saveButton;

    protected void RegisterBaseFields(VisualElement visualElement) {
        this.visualElement = visualElement;
        nameInput = visualElement.Q<TextField>("NameInput");
        bountyInput = visualElement.Q<IntegerField>("BountyInput");
        saveButton = visualElement.Q<Button>("SaveButton");
        nameInput.RegisterValueChangedCallback((v) => Component.Name = v.newValue);
        bountyInput.RegisterValueChangedCallback((v) => Component.Bounty = v.newValue);
        saveButton.RegisterCallback<ClickEvent>((v) => Save());
    }

    public void UpdateComponent(T comp) {
        if (comp == null) ClearAllFields();
        else {
            FillAllFields(comp);
        }
    }

    protected abstract void Save();

    private void FillAllFields(T comp) {
        Component = (T)comp.Clone();
        nameInput.value = comp.Name;
        bountyInput.value = comp.Bounty;
        nameInput.focusable = false;
        FillCustomFields();
    }
    protected abstract void FillCustomFields();

    protected void ClearAllFields() {
        Component = new T();
        nameInput.value = "";
        bountyInput.value = 0;
        nameInput.focusable = true;
        ClearCustomFields();
    }
    protected abstract void ClearCustomFields();
}
