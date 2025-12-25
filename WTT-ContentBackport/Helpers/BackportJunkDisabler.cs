using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Services;

namespace WTTContentBackport.Helpers;


[Injectable]
public class BackportJunkDisabler(DatabaseService databaseService, PmcConfig pmcConfig, ItemConfig itemConfig)
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

    private readonly List<MongoId> _itemsToBlacklist = new()
    {
"68f117b8121d878a2303eee0", // LP Gamma
"68f8e04eae031982b00e7aaf", // Battle Worn Gamma
"68d55968ca9935b3f10607a9", // LP Fanny
    };
    private void AddDogtagsToPmCs()
    {
        var bearDogtagSettings = pmcConfig.DogtagSettings["bear"];
        var usecDogtagSettings = pmcConfig.DogtagSettings["usec"];
        foreach (var newDogtag in _usecDogtags)
        {
            foreach (var profileVersion in usecDogtagSettings)
            {
                profileVersion.Value[newDogtag] = 1;
            }
        }
        foreach (var newDogtag in _bearDogtags)
        {
            foreach (var profileVersion in bearDogtagSettings)
            {
                profileVersion.Value[newDogtag] = 1;
            }
        }
    }
    
    private void AddItemsToRewardItemBlacklist()
    {
        foreach (var newItem in _bearDogtags)
        {
            itemConfig.Blacklist.Add(newItem);
        }

        foreach (var newItem in _usecDogtags)
        {
            itemConfig.Blacklist.Add(newItem);
        }
    }
    
}