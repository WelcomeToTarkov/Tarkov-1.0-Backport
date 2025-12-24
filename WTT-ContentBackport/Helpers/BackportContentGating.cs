using SPTarkov.Server.Core.Extensions;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Eft.Profile;
using WTTServerCommonLib.Helpers;

namespace WTTContentBackport.Helpers;

public static class BackportContentGating
{
    /// <summary>
    /// Add all dev customisations from the JSON list to dev profiles only.
    /// </summary>
    public static int AddAllDevCustomisations(this SptProfile profile)
    {
        var devCustomisations = new (MongoId Id, string Type)[]
        {
            ("68fb6aa63545a39de907326f", "ceiling"),
            ("68fb6abe365db7fe8a0e25ef", "ceiling"),
            ("68fb36c5f91674307c06674d", "dogTag"),
            ("68fb35fb2cff66eb7a008ea8", "dogTag"),
            ("68f15e9fcacd763bbc0e2bd8", "dogTag"),
            ("68fb6a703545a39de9073267", "floor"),
            ("68fb6a7cf91c87952f0c4fe5", "floor"),
            ("675466ea8b3797a0e8038bd2", "floor"),
            ("68f615b0c7592f88510b1c32", "shootingRangeMark"),
            ("68f6159355deae75be0f3bb6", "shootingRangeMark"),
            ("68f1500a8e0bff44ce023f1e", "shootingRangeMark"),
            ("68f151258e0bff44ce023f20", "shootingRangeMark"),
            ("68f1516fd4bee20384008afa", "shootingRangeMark"),
            ("68f151bf79e73568c40a7938", "shootingRangeMark"),
            ("68f11506a1e799f1c3027c79", "shootingRangeMark"),
            ("690d4eda458927196f0775f8", "voice"),
            ("68fb6a28f0b98c76ea0dc313", "wall"),
            ("68fb6a584e7ecdb1220adfa5", "wall"),
            ("6746fd09bafff85008048838", "dogTag"),
            ("67471938bafff850080488b7", "dogTag"),
            ("68df9aa45d4e135b130392d0", "ceiling"),
            ("68df9aaf637781242a0b22fa", "ceiling"),
            ("68df9a2d3772634bf40f4f1a", "floor"),
            ("68df9ac5a38a5e37d80df6cd", "wall"),
            ("68df9a14972cf1e1ec07256c", "floor"),
            ("68df9abc5d4e135b130392d2", "wall"),
            ("68df9a925d4e135b130392ce", "ceiling"),
            ("68df9a053772634bf40f4f18", "floor"),
            ("68df9b2642e96f583d042b8c", "wall"),
            ("68df9b2e3772634bf40f4f1c", "wall"),
            ("68df9a9ba38a5e37d80df6cb", "ceiling"),
            ("68df9a222e6cd294e908d1eb", "floor")
        };
        
        return profile.AddDevOnlyCustomisations(devCustomisations, CustomisationSource.UNLOCKED_IN_GAME);
    }
}