using System.Reflection;
using EFT.Hideout;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace WTTContentBackportClient.Patches;

public class MannequinPatch : ModulePatch
{
    protected override MethodBase GetTargetMethod()
    {
        return AccessTools.Method(typeof(HideoutAreaStashController), nameof(HideoutAreaStashController.Init));
    }

    [PatchPostfix]
    private static void PatchPostfix(HideoutAreaStashController __instance)
    {
        if (Plugin.MannequinController == null)
        {
            Plugin.Log.LogError("AnimatorController is null, cannot apply mannequin animator.");
            return;
        }

        __instance.InventoryEquipmentStashLoader.RuntimeAnimatorController_0 = Plugin.MannequinController;
    }
}