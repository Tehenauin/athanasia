using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public static class CharacterComponentLoader
{
    public static UnityEvent ComponentsUpdated = new UnityEvent();

    public static List<CharacterComponent> Components;
    public static void LoadComponents() {
        var forms = Utility.LoadAllFilesInFolder<Form>(Paths.FormsFolder);
        var genes = Utility.LoadAllFilesInFolder<Gene>(Paths.GenesFolder);
        var classes = Utility.LoadAllFilesInFolder<CClass>(Paths.ClassesFolder);
        var abilities = Utility.LoadAllFilesInFolder<Ability>(Paths.AbilitiesFolder);

        Components = new List<CharacterComponent>();
        Components.AddRange(forms);
        Components.AddRange(genes);
        Components.AddRange(classes);
        Components.AddRange(abilities);
    }

    public static void SaveComponent(CharacterComponent c) {

        if (c.Name == "" || c.Name == null) {
            Debug.Log("Name Invalid");
            return;
        }
        Utility.SaveYamlFile(c.Name, c, Paths.TypeFolder(c));
        AddComponent(c);
        ComponentsUpdated.Invoke();
    }

    static void AddComponent(CharacterComponent component) {
        CharacterComponent[] comps = Components.Where((c) => c.Name == component.Name && component.GetType() == c.GetType()).ToArray();
        if(comps.Length == 0) {
            Components.Add(component);
        } else if(comps.Length == 1) {
            int index = Components.IndexOf(comps[0]);
            Components[index] = component;
        } else {
            Debug.Log($"ERROR: Found multiple Components of name {component.Name} and Type {component.GetType()}");
        }
    }

}
