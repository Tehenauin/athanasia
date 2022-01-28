using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EditorController : MonoBehaviour
{
    private VisualElement root;
    private Button editSelectedButton;
    private Button newFromSelectedButton;
    Dictionary<Type, Button> newComponentButtons;

    private FormEditor formEditor;

    private void Start() {
        root = GetComponent<UIDocument>().rootVisualElement;
        formEditor = new FormEditor(root.Q<VisualElement>("FormEditor"));
        CharacterComponentDrawer.ComponentSelect.AddListener(OnComponentSelect);
    }

    private void OnComponentSelect(CharacterComponent c) {
        switch (c) {
            case Form form:
                formEditor.UpdateForm(form);
                break;
            default:
                break;
        }
    }
}
