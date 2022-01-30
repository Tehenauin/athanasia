using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;

public abstract class CharacterComponentEditor<T> where T : CharacterComponent, new() {
    [HideInInspector] [SerializeField] protected T Component;

    protected VisualElement visualElement;

    protected List<IComponentEditorField> editorFields = new List<IComponentEditorField>();
    StringInputField nameInput;

    [SerializeField] protected Button saveButton;



    protected void RegisterBaseFields(VisualElement visualElement) {
        this.visualElement = visualElement;

        nameInput = new StringInputField(visualElement, "NameInput", v => Component.Name = v, () => Component.Name);
        editorFields.Add(nameInput);
        
        saveButton = visualElement.Q<Button>("SaveButton");;
        saveButton.RegisterCallback<ClickEvent>((v) => Save());
    }

    public void UpdateComponent(T comp) {
        if (comp == null) ClearAllFields();
        else {
            FillAllFields(comp);
        }
    }

    protected void Save() {
        foreach (var field in editorFields) {
            field.Read();
        }
        nameInput.SetInteractable(false);
        CharacterComponentLoader.SaveComponent(Component);
    }

        private void FillAllFields(T comp) {
        Component = (T)comp.Clone();
        nameInput.SetInteractable(false);
        foreach (var field in editorFields) {
            field.Fill();
        }
    }

    protected void ClearAllFields() {
        Component = new T();
        nameInput.SetInteractable(false);
        foreach(var field in editorFields) {
            field.Clear();
        }
    }
}
