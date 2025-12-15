using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;

namespace WTTContentBackport.Helpers
{
    [Injectable]
    public class BackportQuestHelper(DatabaseService  databaseService, ISptLogger<BackportQuestHelper> logger)
    {

        // Define weapon IDs
        // ReSharper disable InconsistentNaming
        // ReSharper disable IdentifierTypo
        
        // Assault Carbine
        private const string ASVAL_MOD4 = "6871284e9a353bb50606f3ed";
        
        // Assault Rifle
        private const string RADIAN_MODEL1 = "6895bb82c4519957df062f82";
        private const string M16A1 = "68a639748e1fe612970728e9";
        private const string NL545 = "68c2940aecc41cc5490bd40e";
        private const string NL545_DI = "68c16b9ab6b75a8a480520a6";
        private const string AK308 = "689166b6c2d6fa42e7044756";
        private const string M16A2 = "68a6399922b1e0bd360afe56";
        
        // Marksman Rifle
        private const string TKPD = "68aee763130c00663d08aea8";
        
        // Sniper Rifle
        private const string MXLR = "67c6de3ce39861860909e8e5";
        
        // Armor (and Armored Rigs)
        private const string armor_6B45 = "68948a95d8f2b85fb705e2a6";
        private const string armor_6B45_armoredrig = "68948ad72c87773b9f06d73f";
        private const string armor_6B45_armoredrigAssault = "68948b118c57a8a52301d7ae";
        private const string armor_6B45_armoredrigMedic = "68948aebd8f2b85fb705e2b0";
        private const string armor_OTV_woodland = "68a89942431252e29a02dbf6";
        private const string armor_THOR_CRL = "68a89146212dbbeead0d5636";
        private const string armor_FCPC_BD = "689479cb47e5acd1e10be986";
        private const string armor_Siege_R_BD = "68947a4be4bf255d1b0ca746";
        private const string armor_LV119_BD = "689479eb30cc5ba7be00f5ff";
        private const string armor_LV119_BD1 = "689479a4a733b1602007e2eb";
        private const string armor_SPPCV2 = "68a99207aa809946e507c2f6";
        private const string armor_KlASS_Kamysh = "68a97093431252e29a02dc06";
        private const string armor_Strandhogg_ABUPAT = "68a85ab8ef22d08bf401fa68";
        
        
        // Helmets
        private const string helmet_Vulkan5_FLAME = "68a98762609a5cb2120ebd26";
        private const string helmet_Vulkan5_CAMO = "68a987a1609a5cb2120ebd2f";
        private const string helmet_Champion = "68bee28f79c8186398098e6f";
        private const string helmet_neosteel_aces = "68a9beecbba00932ed0bc256";
        private const string helmet_ulach_sand = "68bee2ccd6da72c13f03db95";
        private const string helmet_galvion_mutualist = "68a9b5a5863d2a71fa0494a6";
        private const string helmet_Caiman_MultiCam = "68a9b3ca0a9c4f9398032c46";
        private const string helmet_Ronin_Respirator_green = "68a9a92b838d65bcb3050176";
        private const string helmet_Ronin_Respirator_beast = "68a9a85c3e1ee5a70504c12e";
        private const string helmet_NeoSteel_Orange = "68a9be93f260f4e1c2038686";
        private const string helmet_hardhat_white = "68a6d96fddf0111c2f04c9c9";
        private const string helmet_ULACH_greenstripes = "68bee2d9af253218c00ebbb4";
        private const string helmet_hardhat_orange = "68a6d95addf0111c2f04c9c3";
        private const string helmet_ULACH_meshspray = "68bee2e0ede5c8489f08e1b5";
        private const string helmet_LShZ5_Eightball = "68a986ca5c0073fa2d0d8cb8";
        private const string helmet_ULACH_coyotestripe = "68bee2e876e02b9e340ef113";
        
        // Facecovers (armored)

        private const string facecover_Atomic_ping = "688b3bfa1ed594eccd0c45ee";
        private const string facecover_deathshadow_gold = "68a9b821cdf661cc5a0626c6";
        private const string facecover_Samurai_menpo = "68bee22e79c8186398098e6d";
        private const string facecover_Samurai_menpo_gold = "68bee238a48c3c320808abc4";
        private const string facecover_Atomic_toxic = "68a9a0b01696fb8c1e0ee9cc";
        private const string facecover_Samurai_menpo_white = "68bee246ede5c8489f08e1b3";
        private const string facecover_deathshadow_gray = "68a9b852cdf661cc5a0626c9";
        private const string facecover_Atomic_crashtested = "68a9a1223e1ee5a70504c126";
        private const string facecover_deathshadow_white = "68a9b873a4b28d56c80a1818";
        private const string facecover_Atomic_LouiPeeton4 = "68d54d0525ac8590a8075ac3";
        private const string facecover_Atomic_LouiPeeton3 = "68a9a04373d52d47830759c7";
        private const string facecover_Atomic_demonic = "68a9a15d73d52d47830759c9";
        
        
        public void ModifyQuests()
        {
            var quests = databaseService.GetTemplates().Quests;

            // ReSharper disable CommentTypo
            // ====================== PRAPOR QUESTS ======================

            
            // Punisher Part 4 (59ca264786f77445a80ed044)
            //AddWeaponsToKillCondition(quests, "59ca264786f77445a80ed044", []);
            
            // Punisher Part 6 (59ca2eb686f77445a80ed049)
            //AddWeaponsToKillCondition(quests, "59ca2eb686f77445a80ed049", []);

            // Mall Cop (64e7b99017ab941a6f7bf9d7)
            //AddWeaponsToKillCondition(quests, "64e7b99017ab941a6f7bf9d7", []);

            // Tickets, Please (64e7b9a4aac4cd0a726562cb)
            //AddWeaponsToKillCondition(quests, "64e7b9a4aac4cd0a726562cb", []);

            // District Patrol (64e7b9bffd30422ed03dad38)
            AddWeaponsToKillCondition(quests, "64e7b9bffd30422ed03dad38", [
                ASVAL_MOD4, RADIAN_MODEL1, M16A1, NL545, NL545_DI, AK308, M16A2
            ]);

            // ====================== SKIER QUESTS ======================

            // Stirrup (596b455186f77457cb50eccb)
            //AddWeaponsToKillCondition(quests, "596b455186f77457cb50eccb", []);

            // Silent Caliber (5c0bc91486f7746ab41857a2)
            //AddWeaponsToKillCondition(quests, "5c0bc91486f7746ab41857a2", []);

            // Setup (5c1234c286f77406fa13baeb)
            //AddWeaponsToKillCondition(quests, "5c1234c286f77406fa13baeb", []);

            // Connections Up North (6764174c86addd02bc033d68)
            AddWeaponsToKillCondition(quests, "6764174c86addd02bc033d68", [
                MXLR
            ]);

            // ====================== PEACEKEEPER QUESTS ======================

            // Spa Tour Part 1 (5a03153686f77442d90e2171)
            //AddWeaponsToKillCondition(quests, "5a03153686f77442d90e2171", []);

            // Worst Job (63a9b229813bba58a50c9ee5)
            AddWeaponsToKillCondition(quests, "63a9b229813bba58a50c9ee5", [
                M16A2, M16A1, RADIAN_MODEL1
            ]);

            // ====================== JAEGER QUESTS ======================

            var allArmors = new[]
            {
                armor_6B45, armor_6B45_armoredrig, armor_6B45_armoredrigAssault, armor_6B45_armoredrigMedic, armor_OTV_woodland, armor_THOR_CRL, armor_FCPC_BD, armor_Siege_R_BD, armor_LV119_BD, armor_LV119_BD1, armor_SPPCV2, armor_KlASS_Kamysh, armor_Strandhogg_ABUPAT
            };

            var allHelmets = new[]
            {
                helmet_Vulkan5_FLAME, helmet_Vulkan5_CAMO, helmet_Champion, helmet_neosteel_aces, helmet_ulach_sand, helmet_galvion_mutualist, helmet_Caiman_MultiCam, helmet_Ronin_Respirator_beast, helmet_Ronin_Respirator_green, helmet_NeoSteel_Orange, helmet_hardhat_white, helmet_ULACH_greenstripes, helmet_hardhat_orange, helmet_ULACH_meshspray, helmet_LShZ5_Eightball, helmet_ULACH_coyotestripe
            };

            var allFaceCovers = new[]
            {
                facecover_Atomic_crashtested, facecover_Atomic_demonic, facecover_Atomic_LouiPeeton3, facecover_Atomic_LouiPeeton4, facecover_Atomic_ping, facecover_Atomic_toxic, facecover_deathshadow_gold, facecover_deathshadow_gray, facecover_deathshadow_white, facecover_Samurai_menpo, facecover_Samurai_menpo_gold, facecover_Samurai_menpo_white
            };

            // Tarkov Shooter Part 1-8
            AddWeaponsToKillCondition(quests, "5bc4776586f774512d07cf05", [MXLR]); // Part 1
            AddWeaponsToKillCondition(quests, "5bc479e586f7747f376c7da3", [MXLR]); // Part 2
            AddWeaponsToKillCondition(quests, "5bc47dbf86f7741ee74e93b9", [MXLR]); // Part 3
            AddWeaponsToKillCondition(quests, "5bc480a686f7741af0342e29", [MXLR]); // Part 4
            AddWeaponsToKillCondition(quests, "5bc4826c86f774106d22d88b", [MXLR]); // Part 5
            AddWeaponsToKillCondition(quests, "5bc4836986f7740c0152911c", [MXLR]); // Part 6
            AddWeaponsToKillCondition(quests, "5bc4856986f77454c317bea7", [MXLR]); // Part 7
            AddWeaponsToKillCondition(quests, "5bc4893c86f774626f5ebf3e", [MXLR]); // Part 8

            // Claustrophobia (669fa3979b0ce3feae01a130)
            //AddWeaponsToKillCondition(quests, "669fa3979b0ce3feae01a130", []);

            // ====================== MECHANIC QUESTS ======================

            // Psycho Sniper (5c0be13186f7746f016734aa)
            AddWeaponsToKillCondition(quests, "5c0be13186f7746f016734aa", [
                MXLR
            ]);

            // Shooter Born in Heaven (5c0bde0986f77479cf22c2f8)
            AddWeaponsToKillCondition(quests, "5c0bde0986f77479cf22c2f8", [
                MXLR
            ]);

            // Make Amends Equipment (6261482fa4eb80027c4f2e11)
            //AddWeaponsToFindOrHandoverCondition(quests, "6261482fa4eb80027c4f2e11", []);
            
            // Survivalist Path Unprotected but Dangerous (5d25aed386f77442734d25d2)
            AddArmorToEquipmentExclusive(quests, "5d25aed386f77442734d25d2", allArmors);
            
            // Swift One (60e729cf5698ee7b05057439)
            AddArmorToEquipmentExclusive(quests, "60e729cf5698ee7b05057439", allArmors);
            AddArmorToEquipmentExclusive(quests, "60e729cf5698ee7b05057439", allHelmets);
            AddArmorToEquipmentExclusive(quests, "60e729cf5698ee7b05057439", allFaceCovers);
        }

        private void AddWeaponsToKillCondition(Dictionary<MongoId, Quest> quests, string questId, string[] weaponIds)
        {
            if (!quests.TryGetValue(questId, out var quest) || quest.Conditions.AvailableForFinish == null)
                return;

            foreach (var condition in quest.Conditions.AvailableForFinish)
            {
                if (condition is { ConditionType: "CounterCreator", Counter.Conditions: not null })
                {
                    foreach (var counterCond in condition.Counter.Conditions)
                    {
                        if (counterCond is { ConditionType: "Kills", Weapon: not null })
                        {
                            foreach (var weaponId in weaponIds)
                            {
                                counterCond.Weapon.Add(weaponId);
                                
                            }
                        }
                    }
                }
            }
        }
        
        private void AddArmorToEquipmentExclusive(Dictionary<MongoId, Quest> quests, string questId, string[] armorIds)
        {
            if (!quests.TryGetValue(questId, out var quest) || quest.Conditions.AvailableForFinish == null)
                return;

            foreach (var condition in quest.Conditions.AvailableForFinish)
            {
                if (condition is { ConditionType: "CounterCreator", Counter.Conditions: not null })
                {
                    foreach (var counterCond in condition.Counter.Conditions)
                    {
                        if (counterCond is { ConditionType: "Equipment", EquipmentExclusive: not null })
                        {
                            foreach (var armorId in armorIds)
                            {
                                counterCond.EquipmentExclusive.Add([armorId]);
                            }
                        }
                    }
                }
            }
        }

        private void AddWeaponsToFindOrHandoverCondition(Dictionary<MongoId, Quest> quests, string questId, string[] weaponIds)
        {
            if (!quests.TryGetValue(questId, out var quest) || quest.Conditions.AvailableForFinish == null)
                return;

            foreach (var condition in quest.Conditions.AvailableForFinish)
            {
                if ((condition.ConditionType == "FindItem" || condition.ConditionType == "HandoverItem") && condition.Target != null)
                {
                    foreach (var weaponId in weaponIds)
                    {
                        if (condition.Target.List != null && !condition.Target.List.Contains(weaponId))
                        {
                            condition.Target.List.Add(weaponId); 
                            
                        }
                    }
                }
            }
        }
    }
}
