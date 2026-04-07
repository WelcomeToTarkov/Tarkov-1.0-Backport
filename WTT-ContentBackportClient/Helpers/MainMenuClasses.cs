
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using EFT;
using UnityEngine;

public sealed class CustomEnvironmentDefinition
{
    public EEnvironmentUIType Type { get; set; }
    public string BundlePath { get; set; }
    public string ScenePath { get; set; }
    public string SceneName { get; set; }
}

public static class CustomEnvironmentRegistry
{
    private static readonly string PluginFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // or your plugin subfolder if needed

    public static readonly CustomEnvironmentDefinition[] Definitions =
    {
        new()
        {
            Type = (EEnvironmentUIType)6,
            BundlePath = Path.Combine(PluginFolder, "miami.bundle"),
            ScenePath = "Assets/EnvironmentUISceneMiami/Scenes/UI/EnvironmentUISceneMiami.unity",
            SceneName = "EnvironmentUISceneMiami"
        },
        new()
        {
            Type = (EEnvironmentUIType)7,
            BundlePath = Path.Combine(PluginFolder, "endings.bundle"),
            ScenePath = "Assets/Endings/Scenes/UI/EndingsScenes/EnvironmentUISceneAndSurvived.unity",
            SceneName = "EnvironmentUISceneAndSurvived"
        },
        new()
        {
            Type = (EEnvironmentUIType)8,
            BundlePath = Path.Combine(PluginFolder, "endings.bundle"),
            ScenePath = "Assets/Endings/Scenes/UI/EndingsScenes/EnvironmentUISceneDidntEscapeFromYourself.unity",
            SceneName = "EnvironmentUISceneDidntEscapeFromYourself"
        },
        new()
        {
            Type = (EEnvironmentUIType)9,
            BundlePath = Path.Combine(PluginFolder, "endings.bundle"),
            ScenePath = "Assets/Endings/Scenes/UI/EndingsScenes/EnvironmentUISceneForHumanity.unity",
            SceneName = "EnvironmentUISceneForHumanity"
        },
        new()
        {
            Type = (EEnvironmentUIType)10,
            BundlePath = Path.Combine(PluginFolder, "endings.bundle"),
            ScenePath = "Assets/Endings/Scenes/UI/EndingsScenes/EnvironmentUISceneInTheDarkness.unity",
            SceneName = "EnvironmentUISceneInTheDarkness"
        }
    };

    public static readonly IReadOnlyDictionary<EEnvironmentUIType, CustomEnvironmentDefinition> ByType =
        Definitions.ToDictionary(x => x.Type);
}

public static class CustomEnvironmentBundleLoader
{
    private static readonly Dictionary<string, AssetBundle> LoadedBundles =
        new(StringComparer.OrdinalIgnoreCase);

    public static bool EnsureLoaded(CustomEnvironmentDefinition def, ManualLogSource logger)
    {
        if (LoadedBundles.TryGetValue(def.BundlePath, out var existing) && existing != null)
            return true;

        if (!File.Exists(def.BundlePath))
        {
            logger.LogError($"Bundle file missing: {def.BundlePath}");
            return false;
        }

        var bundle = AssetBundle.LoadFromFile(def.BundlePath);
        if (bundle == null)
        {
            logger.LogError($"Failed to load AssetBundle: {def.BundlePath}");
            return false;
        }

        var scenePaths = bundle.GetAllScenePaths();

        if (!scenePaths.Any(p => string.Equals(p, def.ScenePath, StringComparison.OrdinalIgnoreCase)))
        {
            logger.LogError($"Bundle does not contain expected scene path: {def.ScenePath}");
            bundle.Unload(false);
            return false;
        }

        LoadedBundles[def.BundlePath] = bundle;
        return true;
    }
}