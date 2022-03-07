using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorControllerNew : MonoBehaviour
{
    private CharacterComponentEditorNew currentEditor;
    private Dictionary<Type, CharacterComponentEditorNew> editorsDict;

    [SerializeField] private List<CharacterComponentEditorNew> editors;

    private void Awake() {
        editorsDict = new Dictionary<Type, CharacterComponentEditorNew>();
        foreach(var ed in editors) {
            editorsDict[ed.type] = ed;
        }
    }

    private void Save() {
    }
}
