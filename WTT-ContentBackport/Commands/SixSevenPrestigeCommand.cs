using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Helpers.Dialog.Commando.SptCommands;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Eft.Dialog;
using SPTarkov.Server.Core.Models.Eft.Profile;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;
using WTTServerCommonLib.Helpers;

namespace WTTContentBackport.Commands;

[Injectable]
public class SixSevenPrestigeCommand(
    DatabaseServer databaseServer,
    MailSendService mailSendService,
    RewardHelper rewardHelper,
    ProfileHelper profileHelper) : ISptCommand
{
    public ValueTask<string> PerformAction(UserDialogInfo commandHandler, MongoId sessionId, SendMessageRequest request)
    {
        mailSendService.SendUserMessageToPlayer(sessionId, commandHandler, $"This REQUIRES a full game restart in order to see the new Head options");
        var profile = profileHelper.GetFullProfile(sessionId);
        rewardHelper.AddAchievementToProfile(profile, "6948990c05f4f91bdb9a56f3");
        rewardHelper.AddAchievementToProfile(profile, "694c6575af08f6f1d59a5737");
        
        IEnumerable<MongoId> prestigeHeads = new MongoId[]
        {
            "68fb8872fb3842532002cbc1",
            "68fb88b9d4b0e9617502c1c4",
        };
        profile.AddCustomisations(prestigeHeads, "head", CustomisationSource.DEFAULT);
        return new ValueTask<string>(request.DialogId);
    }

    public string Command
    {
        get { return "67prestige"; }
    }

    public string CommandHelp
    {
        get
        {
            return "Usage: Receive Prestige 5 and 6 content";
        }
    }
}