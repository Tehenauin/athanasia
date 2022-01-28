using UnityEngine;
using UnityEngine.UIElements;

public class GeneEditor : ComponentEditor<Gene> {
    [SerializeField] private StatsEditor statsEditor;

    public GeneEditor(VisualElement visualElement) {
        RegisterBaseFields(visualElement);
        statsEditor = new StatsEditor(visualElement.Q<VisualElement>("StatsEditor"));
        ClearAllFields();
    }

    protected override void Save() {
        Component.stats = statsEditor.stats;
        nameInput.focusable = false;
        CharacterComponentLoader.SaveComponent(Component);
    }

    protected override void FillCustomFields() {
        statsEditor.fill(base.Component.stats);
    }
    protected override void ClearCustomFields() {
        statsEditor.fill(CharacterStats.defaultStats);
    }
}
