
using UnityEngine.UIElements;

public class AbilityEditor : CharacterComponentEditor<Ability> {
    public AbilityEditor(VisualElement visualElement) {
        RegisterBaseFields(visualElement);

        editorFields.Add(new IntInputField(visualElement, "TickCostEditor", (v) => Component.TickCost = v, () => Component.TickCost));
        editorFields.Add(new StatsInputField(visualElement, "StatsEditor", (v) => Component.Stats = v, () => Component.Stats));
        editorFields.Add(new StringInputField(visualElement, "DescriptionEditor", (v) => Component.Description = v, () => Component.Description));

        ClearAllFields();
    }
}
