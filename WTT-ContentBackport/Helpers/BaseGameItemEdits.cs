using HarmonyLib;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;
using WTTServerCommonLib.Helpers;

namespace WTTContentBackport.Helpers;

[Injectable(typePriority: OnLoadOrder.PostDBModLoader + 3)]
public class BaseGameItemEdits(
    ISptLogger<BaseGameItemEdits> logger,
    DatabaseService databaseService,
    SlotHelper slotHelper
):IOnLoad
{

    public Task OnLoad()
    {
        EditFilters();
        return Task.CompletedTask;
    }

    private void EditFilters()
    {
        var dbItems = databaseService.GetItems();
        foreach (var (id, item) in dbItems)
        {
            switch (id)
            {
                case "652910ef50dc782999054b97":
                    slotHelper.EnsureSlot(item, "mod_tactical", "55d30c4c4bdc2db4468b457e", false, false, 0);
                    
                    slotHelper.AddIdsToNamedSlot(item, "mod_mount_000",
                        "689c8a2b4b91399db3085f27");

                    slotHelper.AddIdsToNamedSlot(item, "mod_mount_001",
                        "689c8a2b4b91399db3085f27");

                    slotHelper.AddIdsToNamedSlot(item, "mod_mount_002",
                        "689c8a2b4b91399db3085f27");

                    slotHelper.AddIdsToNamedSlot(item, "mod_tactical",
                        "57fd23e32459772d0805bcf1",
                        "544909bb4bdc2d6f028b4577",
                        "5d10b49bd7ad1a1a560708b0",
                        "5c06595c0db834001a66af6c",
                        "5a7b483fe899ef0016170d15",
                        "61605d88ffa6e502ac5e7eeb",
                        "5c5952732e2216398b5abda2",
                        "644a3df63b0b6f03e101e065",
                        "68bedc0365e7dcf94f0cb0fc");
                    break;
                case "652910565ae2ae97b80fdf35":
                    item.Properties.Slots.First().Properties.Filters.First().Filter = [
                        "607ffb988900dc2d9a55b6e4",
                        "5cdd7693d7f00c0010373aa5",
                        "5bbdb8bdd4351e4502011460",
                        "5d02677ad7ad1a04a15c0f95",
                        "5c878e9d2e2216000f201903",
                        "5cdd7685d7f00c000f260ed2",
                        "6130c43c67085e45ef1405a1",
                        "5dfa3cd1b33c0951220c079b",
                        "5d026791d7ad1a04a067ea63",
                        "5dcbe965e4ed22586443a79d",
                        "6642f63667f5cb56a00662eb",
                        "628a66b41d5e41750e314f34",
                        "5d1f819086f7744b355c219b",
                        "6065c6e7132d4d12c81fd8e1",
                        "618178aa1cb55961fa0fdc80",
                        "5a34fd2bc4a282329a73b4c5",
                        "5b7d693d5acfc43bca706a3d",
                        "612e0d3767085e45ef14057f",
                        "615d8eb350224f204c1da1cf",
                        "612e0e3c290d254f5e6b291d",
                        "5d443f8fa4b93678dd4a01aa",
                        "6529113b5ae2ae97b80fdf39",
                        "5cf78496d7f00c065703d6ca",
                        "5fbc22ccf24b94483f726483",
                        "5c7954d52e221600106f4cc7",
                        "5fbe7618d6fa9c00c571bb6c"
                    ];
                    break;
                case "66bc98a01a47be227a5e956e":
                    item.Properties.Grids.FirstOrDefault().Properties.CellsH = 8;
                    item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter = [
                        "62a09cfe4f842e1bd12da3e4",
                        "5bc9bdb8d4351e003562b8a1",
                        "5bc9bc53d4351e00367fbcee",
                        "66b37ea4c5d72b0277488439",
                        "5f745ee30acaeb0d490d8c5b",
                        "62a091170b9d3c46de5b6cf2",
                        "5e54f62086f774219b0f1937",
                        "66b37eb4acff495a29492407",
                        "5bc9b355d4351e6d1509862a",
                        "60b0f7057897d47c5b04ab94",
                        "5bc9c049d4351e44f824d360",
                        "5e54f6af86f7742199090bf3",
                        "5bc9be8fd4351e00334cae6e",
                        "62a08f4c4f842e1bd12d9d62",
                        "5bc9c377d4351e3bac12251b",
                        "66b37f114410565a8f6789e2",
                        "62a09e73af34e73a266d932a",
                        "62a09e974f842e1bd12da3f0",
                        "60b0f988c4449e4cb624c1da",
                        "62a09d79de7ac81993580530",
                        "62a09dd4621468534a797ac7",
                        "5e54f79686f7744022011103",
                        "5e54f76986f7740366043752",
                        "60b0f6c058e0b0481a09ad11",
                        "62a09d3bcf4a99369e262447",
                        "62a09e410b9d3c46de5b6e78",
                        "60b0f561c4449e4cb624c1d7",
                        "5bc9b9ecd4351e3bac122519",
                        "60b0f93284c20f0feb453da7",
                        "5bc9c29cd4351e003562b8a3",
                        "5bc9b156d4351e00367fbce9",
                        "5bc9c1e2d4351e00367fbcf0",
                        "62a09e08de7ac81993580532",
                        "5bd073a586f7747e6f135799",
                        "62a09ec84f842e1bd12da3f2",
                        "62a09cb7a04c0c5c6e0a84f8",
                        "5bc9b720d4351e450201234b",
                        "5fd8d28367cb5e077335170f",
                        "5bd073c986f7747f627e796c",
                        "6937edb912d456a817083e82",
                        "6937ecf8628ee476240c07cb",
                        "69398e94ca94fd2877039504",
                        "6937f02dfd6488bb27024839"
                    ];
                    break;
                case "5929a2a086f7744f4b234d43":
                    item.Properties.Prefab.Path =
                        "assets/content/items/equipment/rig_6sh112/item_equipment_rig_6sh112.bundle";
                    break;
                case "67586b7e49c2fa592e0d8ed9":
                    item.Parent = "5448e8d04bdc2ddf718b4569";
                    item.Properties.ShortName= "item_food_saladbox";
                    item.Properties.UsePrefab.Path =
                        "assets/content/weapons/usable_items/item_food_saladbox/item_food_saladbox_container.bundle";
                    item.Properties.MaxResource = 1;
                    item.Properties.MetascoreGroup = "Utility";
                    item.Properties.FoodEffectType = "afterUse";
                    item.Properties.FoodUseTime = 5;
                    item.Properties.ItemSound = "generic";
                    item.Properties.RarityPvE = "SuperRare";
                    if (item.Properties.EffectsHealth == null)
                        item.Properties.EffectsHealth = new Dictionary<HealthFactor, EffectsHealthProperties>();

                    // Initialize Energy
                    if (!item.Properties.EffectsHealth.ContainsKey(HealthFactor.Energy))
                        item.Properties.EffectsHealth[HealthFactor.Energy] = new EffectsHealthProperties();

                    item.Properties.EffectsHealth[HealthFactor.Energy].Value = 100;

                    // Initialize Hydration
                    if (!item.Properties.EffectsHealth.ContainsKey(HealthFactor.Hydration))
                        item.Properties.EffectsHealth[HealthFactor.Hydration] = new EffectsHealthProperties();

                    item.Properties.EffectsHealth[HealthFactor.Hydration].Value = -10;

                    break; // manually push new salad box properties
                case "5ae30bad5acfc400185c2dc4":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68a63d1522b1e0bd360afe67"]);
                    break; //Manually push Delta Pic mount to AR-15 carry handle
                
                case "5c093e3486f77430cb02e593":
                    foreach (var dogtag in BackportJunkDisabler._usecDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    foreach (var dogtag in BackportJunkDisabler._bearDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    break; // Manually push dogtags to dogtag case
                case "5d235bb686f77443f4331278":
                    foreach (var dogtag in BackportJunkDisabler._usecDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    foreach (var dogtag in BackportJunkDisabler._bearDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    break; // Manually push dogtags to SICC case
                case "57ac965c24597706be5f975c":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "688b54a11cef2a61d005273b"]);
                    break; //Manually push RMR mount to Elcans
                
                case "57aca93d2459771f2c7e26db":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "688b54a11cef2a61d005273b"]);
                    break; //Manually push RMR mount to Elcans
                
                case "5c0e2f26d174af02a9625114":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68caacb4c8ac87b10507c5a6"]);
                    break; //Manually push MK12 top rail to upper receivers
                
                case "55d355e64bdc2d962f8b4569":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68caacb4c8ac87b10507c5a6"]);
                    break; //Manually push MK12 top rail to upper receivers
                
                case "5c07a8770db8340023300450":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68caacb4c8ac87b10507c5a6"]);
                    break; //Manually push MK12 top rail to upper receivers
                
                case "59bfe68886f7746004266202":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68caacb4c8ac87b10507c5a6"]);
                    break; //Manually push MK12 top rail to upper receivers
                
                case "63f5ed14534b2c3d5479a677":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68caacb4c8ac87b10507c5a6"]);
                    break; //Manually push MK12 top rail to upper receivers
                
                case "5d4405aaa4b9361e6a4e6bd3":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68caacb4c8ac87b10507c5a6"]);
                    break; //Manually push MK12 top rail to upper receivers
                
                case "5df917564a9f347bc92edca3":
                    slotHelper.ModifySlotFilters(item, 1, 0, [
                        "6932aeebbe542622170428ba",
                        "6936bde84737190b66053bb1"]);
                    break; //Manually push M110 gas blocks to SR-25 barrels
                    
                case "5dfa397fb11454561e39246c":
                    slotHelper.ModifySlotFilters(item, 1, 0, [
                        "6932aeebbe542622170428ba",
                        "6936bde84737190b66053bb1"]);
                    break; //Manually push M110 gas blocks to SR-25 barrels
                case "623063e994fc3f7b302a9696":
                    var slotsList = item.Properties.Slots.ToList();
    
                    slotsList.Add(new Slot()
                    {
                        Id = "680b87cae0666b345f05d628",
                        Name = "mod_sight_front",
                        Parent = "623063e994fc3f7b302a9696",
                        MaxCount = 1,
                        MergeSlotWithChildren = false,
                        Prototype = "55d30c4c4bdc2db4468b457e",
                        Properties = new SlotProperties()
                        {
                            Filters = new List<SlotFilter>()
                            {
                                new()
                                {
                                    Filter = ["680b87fc9402a78e7504a057"],
                                    Shift = 0
                                }
                            }
                        },
                        Required = false
                    });
    
                    item.Properties.Slots = slotsList;
                    break; //Manually add new mod_sight_front to g36 template
            }
        }
    }
}