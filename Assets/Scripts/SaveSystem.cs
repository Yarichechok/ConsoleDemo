using System;
using System.IO;
using UnityEngine;

[Serializable] public class SaveData { public int coins; }

public static class SaveSystem
{
    static string P(string f) => Path.Combine(Application.persistentDataPath, f);
    public static void Write(string f, SaveData d) =>
        File.WriteAllText(P(f), JsonUtility.ToJson(d));
    public static SaveData Read(string f) =>
        File.Exists(P(f)) ? JsonUtility.FromJson<SaveData>(File.ReadAllText(P(f))) : new SaveData();
}
