using UnityEngine;
using UnityEngine.UIElements;

public class ClassEditor : CharacterComponentEditor<CClass> {
    public ClassEditor(VisualElement visualElement) {
        RegisterBaseFields(visualElement);

        editorFields.Add(new StatsInputField(visualElement, "StatsEditor", (v) => Component.Stats = v, () => Component.Stats));
        editorFields.Add(new StringInputField(visualElement, "DescriptionEditor", (v) => Component.Description = v, () => Component.Description));

        ClearAllFields();
    }
}
