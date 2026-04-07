using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Comfort.Common;
using EFT;
using EFT.Hideout;
using EFT.UI;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace WTTContentBackportClient.Patches;

public class EnvironmentUIAwakePatch : ModulePatch
{
    protected override MethodBase GetTargetMethod() =>
        AccessTools.Method(typeof(EnvironmentUI), nameof(EnvironmentUI.Awake));

    [PatchPrefix]
    public static void PatchPrefix(EnvironmentUI __instance)
    {
        var field = AccessTools.Field(typeof(EnvironmentUI), "_environments");
        if (field == null)
        {
            Plugin.Log.LogError("Could not find EnvironmentUI._environments");
            return;
        }

        var current = field.GetValue(__instance) as EnvironmentUI.EnvironmentData[];
        var list = current?.ToList() ?? new List<EnvironmentUI.EnvironmentData>();

        foreach (var def in CustomEnvironmentRegistry.Definitions)
        {
            if (list.Any(x => x.Type == def.Type))
                continue;

            list.Add(new EnvironmentUI.EnvironmentData
            {
                Type = def.Type,
                SceneName = def.SceneName,
                EligibleVersions = Array.Empty<string>()
            });

        }

        field.SetValue(__instance, list.ToArray());
    }
}

public class EnvironmentUISetEnvironmentPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod() =>
        AccessTools.Method(typeof(EnvironmentUI), nameof(EnvironmentUI.SetEnvironmentAsync));

    [PatchPrefix]
    public static void PatchPrefix(EnvironmentUI __instance, ref EEnvironmentUIType environmentUiType)
    {
        if (!CustomEnvironmentRegistry.ByType.TryGetValue(environmentUiType, out var def))
            return;

        if (!CustomEnvironmentBundleLoader.EnsureLoaded(def, Plugin.Log))
        {
            Plugin.Log.LogError($"Failed to preload custom environment bundle for type: {environmentUiType}");
        }
    }
}
