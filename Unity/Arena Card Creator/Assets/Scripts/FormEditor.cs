using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
public class FormEditor : CharacterComponentEditor<Form> {
    public FormEditor(VisualElement visualElement) {
        RegisterBaseFields(visualElement);

        editorFields.Add(new StatsInputField(visualElement, "StatsEditor", (v) => Component.Stats = v, () => Component.Stats));

        ClearAllFields();
    }
}