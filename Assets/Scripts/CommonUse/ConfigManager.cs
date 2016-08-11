using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class ConfigManager
{
    public const string ConfigFilePath = "C:/SVNs/BundleTest/Assets/Config.txt";

    public bool IsCleanCache;
    public int TargetBundleVersion;

    public bool LoadConfig()
    {
        if (!File.Exists(ConfigFilePath))
        {
            Debug.LogError("Config file not exist.");
            return false;
        }

        var tables = File.ReadAllLines(ConfigFilePath).Select(item => item.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();

        IsCleanCache = bool.Parse(tables.Where(item => item[0] == "IsCleanCache").First()[1]);
        TargetBundleVersion = int.Parse(tables.Where(item => item[0] == "TargetBundleVersion").First()[1]);

        return true;
    }
}
