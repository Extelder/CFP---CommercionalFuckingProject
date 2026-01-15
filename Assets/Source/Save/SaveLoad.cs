using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SettingsConfigData
{
    [Header("Sensitivity")] public float lookSensitivity = 0.1f;

    [Header("Volumes")] public float masterVolume = 0.8f;
    public float musicVolume = 0.8f;
    public float effectsVolume = 0.8f;

    [Header("Screen")] public bool fullScreen = true;
    public int width;
    public int height;
}

public static class SaveLoad
{
    private static string configDir = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "Dwarf"
    );

    private static string configPath = Path.Combine(configDir, "cfp_config.json");

    public static void Save(SettingsConfigData data)
    {
        if (!Directory.Exists(configDir))
            Directory.CreateDirectory(configDir);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(configPath, json);
    }

    public static SettingsConfigData Load()
    {
        if (File.Exists(configPath))
        {
            string json = File.ReadAllText(configPath);
            return JsonUtility.FromJson<SettingsConfigData>(json);
        }

        return new SettingsConfigData();
    }
}