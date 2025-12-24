using System.Reflection;
using SPTarkov.Reflection.Patching;
using SPTarkov.Server.Core.Extensions;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Models.Eft.Profile;
using WTTContentBackport.Helpers;

namespace WTTExampleMod.Patches;

public class AddCustomisationUnlocksToProfilePatch : AbstractPatch
{
    protected override MethodBase? GetTargetMethod()
    {
        return typeof(FullProfileExtensions).GetMethod(
            "AddCustomisationUnlocksToProfile",
            BindingFlags.Public | BindingFlags.Static
        );
    }

    [PatchPostfix]
    public static void Postfix(SptProfile fullProfile)  // ← Match the parameter name exactly
    {
        var num = fullProfile.AddAllDevCustomisations();
        Console.WriteLine($"Added {num} customisations to dev profile");
    }
}