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