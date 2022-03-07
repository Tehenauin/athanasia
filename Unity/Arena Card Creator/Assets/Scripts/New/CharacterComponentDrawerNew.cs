using System;
using UnityEngine;

public abstract class CharacterComponentDrawerNew<T> : MonoBehaviour where T : CharacterComponent {
    public Type type => typeof(T);
    public abstract void Draw(T component);

}
