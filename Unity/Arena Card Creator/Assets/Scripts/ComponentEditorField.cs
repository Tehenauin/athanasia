
using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public interface IComponentEditorField {

    public void SetInteractable(bool value);
    public void Fill();
    public void Read();
    public void Clear();
}

public class StringInputField : IComponentEditorField {
    TextField textField;
    private Action<string> getter;
    private Func<string> setter;
    private string clearValue;

    public StringInputField(VisualElement rootVisualElement, string visualElementName, Action<string> getter, Func<string> setter, string clearValue = "") {
        textField = rootVisualElement.Q<TextField>(visualElementName);
        this.getter = getter;
        this.setter = setter;
        this.clearValue = clearValue;
    }

    public void Fill() {
        textField.value = setter.Invoke();
    }

    public void Read() {
        getter.Invoke(textField.value);
    }

    public void Clear() {
        textField.value = clearValue;
    }

    public void SetInteractable(bool value) {
        textField.focusable = value;
    }
}

public class IntInputField : IComponentEditorField {
    IntegerField intField;
    private Action<int> getter;
    private Func<int> setter;
    private int clearValue;

    public IntInputField(VisualElement rootVisualElement, string visualElementName, Action<int> getter, Func<int> setter, int clearValue = 0) {
        intField = rootVisualElement.Q<IntegerField>(visualElementName);
        this.getter = getter;
        this.setter = setter;
        this.clearValue = clearValue;
    }

    public void Fill() {
        intField.value = setter.Invoke();
    }

    public void Read() {
        getter.Invoke(intField.value);
    }

    public void Clear() {
        throw new NotImplementedException();
    }

    public void SetInteractable(bool value) {
        intField.focusable = value;
    }
}

public class StatsInputField : IComponentEditorField {
    StatsEditor statsEditor;
    private Action<CharacterStats> getter;
    private Func<CharacterStats> setter;

    public StatsInputField(VisualElement rootVisualElement, string visualElementName, Action<CharacterStats> getter, Func<CharacterStats> setter) {
        statsEditor = new StatsEditor(rootVisualElement.Q<VisualElement>(visualElementName));
        this.getter = getter;
        this.setter = setter;
    }

    public void Fill() {
        statsEditor.Fill(setter.Invoke());
    }

    public void Read() {
        getter.Invoke(statsEditor.stats);
    }

    public void Clear() {
        statsEditor.Fill(CharacterStats.defaultStats);
    }

    public void SetInteractable(bool value) {
        throw new NotImplementedException();
    }
}