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
    private readonly List<MongoId> _bearDogtags = new()
    {
        "68df9908972cf1e1ec07256a",
        "68df9927a38a5e37d80df6c9",
        "68df991142e96f583d042b8a",
        "68df991dbeba86572e097ceb",
        "68f0f63c645c14a02104142a",
        "68fb412b0760c7891606613e",
        "68f15cf222c8979ee308f495",
        "68f0f60a121d878a2303eedb",
        "68fb41120760c7891606613c",
        "68f15e26f1aa7e100a0ca208",
        "68f153aa7da590b6df0515da"
    };
    private readonly List<MongoId> _usecDogtags = new()
    {
        "68df99c05d4e135b130392cc",
        "68df99a614ca2428b2017cd8",
        "68df99b2f716906506098308",
        "68df99975d4e135b130392ca",
        "68f15dbab2b53abd200b9378",
        "68f0f64f183146ea530330aa",
        "68fb4157b280c103230e3b3c",
        "68f0f662859ebec8d501b76a",
        "68fb4143a854bc7ae80fad3e",
        "68f15e53103c5d9d4f022c78",
        "5b9b9020e7ef6f5716480215"
    };
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

                    break;
                case "5ae30bad5acfc400185c2dc4":
                    slotHelper.ModifySlotFilters(item, 0, 0, [
                        "68a63d1522b1e0bd360afe67"]);
                    break; //Manually push Delta Pic mount to AR-15 carry handle
                
                case "5c093e3486f77430cb02e593":
                    foreach (var dogtag in _usecDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    foreach (var dogtag in _bearDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    break;
                case "5d235bb686f77443f4331278":
                    foreach (var dogtag in _usecDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    foreach (var dogtag in _bearDogtags)
                        item.Properties.Grids.FirstOrDefault().Properties.Filters.FirstOrDefault().Filter.Add(dogtag);
                    break;
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
                    item.Properties.Slots.Append(new Slot()
                    {
                        Id = new MongoId(),
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
                                    Filter = ["680b87fc9402a78e7504a057"]
                                }
                            }
                        },
                        Required = false

                    });
                    break; //Manually add new mod_sight_front to g36 template
            }
        }
    }
}