using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using YamlDotNet.Serialization;

public static class Utility
{

    public static int StringToInt(string value) {
        if (Int32.TryParse(value, out int i)) {
            return i;
        } else {
            Debug.LogError($"sting \"{value}\"not castable to int ");
            return 0;
        }
    }

    public static void SaveYamlFile(string name, object obj, string path) {
        string destinationfolder = Application.dataPath + "/Resources"+ path;
        string destination = destinationfolder + "/" + name + ".yaml";

        var serializer = new Serializer();
        string nationYaml = serializer.Serialize(obj);

        if (!Directory.Exists(destinationfolder)) Directory.CreateDirectory(destinationfolder);
        StreamWriter writer = new StreamWriter(destination);
        writer.Write(nationYaml);
        writer.Close();

        Debug.Log("Saved file " + destination);
    }

    public static T[] LoadAllFilesInFolder<T>(string path) {
        path = Application.dataPath + "/Resources" + path;

        if (!Directory.Exists(path)) {
            Debug.LogWarning($"Directory not existing: {path}");
            return new T[0];
        }

        string[] files = Directory.GetFiles(path).Where(f => Path.GetExtension(f) == ".yaml" ).ToArray();

        foreach (var f in files) Debug.Log(f);

        Deserializer deserializer = new Deserializer();
        return files.Select((f) => deserializer.Deserialize<T>(new StreamReader(f).ReadToEnd())).ToArray();
    }

}
