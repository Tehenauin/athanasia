using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterComponentEditorNew<T> : CharacterComponentEditorNew where T : CharacterComponent {
    public override Type type => typeof(T);    
    public abstract void Draw(T component);
    public abstract T Read();
}
public abstract class CharacterComponentEditorNew{
    public abstract Type type { get; }
}
