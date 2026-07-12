using SPTarkov.Reflection.Patching;
using SPTarkov.Server.Core.Extensions;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Eft.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Utils;
using SPTarkov.Server.Core.Utils.Logger;
using System.Reflection;

namespace WTTContentBackport.Patches;

public class FixFencePresetsPatch : AbstractPatch
{
    private static FixFencePresetsPatch? instance;

    private readonly ItemHelper itemHelper;
    private readonly RandomUtil randomUtil;
    private readonly ServerLocalisationService localisationService;
    private readonly ISptLogger<WTTContentBackport> logger;
    private readonly TraderConfig traderConfig;

    public FixFencePresetsPatch(
        ItemHelper itemHelper,
        RandomUtil randomUtil,
        ServerLocalisationService localisationService,
        ISptLogger<WTTContentBackport> logger,
        TraderConfig traderConfig)
    {
        this.itemHelper = itemHelper;
        this.randomUtil = randomUtil;
        this.localisationService = localisationService;
        this.logger = logger;
        this.traderConfig = traderConfig;

        instance = this;
    }

    protected override MethodBase? GetTargetMethod()
    {
        return typeof(FenceService).GetMethod(
            "RandomiseArmorSoftInsertDurabilities",
            BindingFlags.Instance | BindingFlags.NonPublic
        );
    }

    [PatchPrefix]
    public static bool Prefix(
        IEnumerable<Slot> softInsertSlots,
        IEnumerable<Item> armorItemAndMods)
    {
        return instance!.RunPrefix(softInsertSlots, armorItemAndMods);
    }

    private bool RunPrefix(
        IEnumerable<Slot> softInsertSlots,
        IEnumerable<Item> armorItemAndMods)
    {
        foreach (var requiredSlot in softInsertSlots)
        {
            var modItemToAdjust = armorItemAndMods.FirstOrDefault(mod =>
                string.Equals(mod.SlotId, requiredSlot.Name, StringComparison.OrdinalIgnoreCase));

            if (modItemToAdjust == null)
            {
                continue;
            }

            var modItemDbDetails = itemHelper.GetItem(modItemToAdjust.Template).Value;
            if (modItemDbDetails == null)
            {
                logger.Error(
                    localisationService.GetText(
                        "fence-unable_to_find_soft_insert_template_for_slot",
                        modItemToAdjust.Template));

                continue;
            }

            var durabilityValues = GetRandomisedArmorDurabilityValues(
                modItemDbDetails,
                traderConfig.Fence.ArmorMaxDurabilityPercentMinMax);

            modItemToAdjust.AddUpd();

            modItemToAdjust.Upd.Repairable ??= new UpdRepairable
            {
                Durability = modItemDbDetails.Properties.MaxDurability,
                MaxDurability = modItemDbDetails.Properties.MaxDurability,
            };

            modItemToAdjust.Upd.Repairable.Durability = durabilityValues.Durability;
            modItemToAdjust.Upd.Repairable.MaxDurability = durabilityValues.MaxDurability;

            if (
                randomUtil.GetChance100(25)
                && modItemToAdjust.ParentId == BaseClasses.ARMORED_EQUIPMENT
                && modItemToAdjust.SlotId == "mod_equipment_000"
                && modItemToAdjust.Upd.Repairable.Durability < modItemDbDetails.Properties.MaxDurability
            )
            {
                modItemToAdjust.Upd.FaceShield = new UpdFaceShield { Hits = randomUtil.GetInt(1, 3) };
            }
        }

        return false;
    }

    private UpdRepairable GetRandomisedArmorDurabilityValues(
        TemplateItem itemDetails,
        ItemDurabilityCurrentMax equipmentDurabilityLimits)
    {
        var maxDuraMin = equipmentDurabilityLimits.Max.Min / 100d * itemDetails.Properties.MaxDurability;
        var maxDuraMax = equipmentDurabilityLimits.Max.Max / 100d * itemDetails.Properties.MaxDurability;
        var chosenMaxDurability = randomUtil.GetDouble(maxDuraMin.Value, maxDuraMax.Value);

        var currentDuraMin = equipmentDurabilityLimits.Current.Min / 100d * itemDetails.Properties.MaxDurability;
        var currentDuraMax = equipmentDurabilityLimits.Current.Max / 100d * itemDetails.Properties.MaxDurability;
        var chosenCurrentDurability = Math.Min(
            randomUtil.GetDouble(currentDuraMin.Value, currentDuraMax.Value),
            chosenMaxDurability);

        return new UpdRepairable
        {
            Durability = chosenCurrentDurability,
            MaxDurability = chosenMaxDurability
        };
    }
}