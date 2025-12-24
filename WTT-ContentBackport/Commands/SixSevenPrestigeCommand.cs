using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Helpers.Dialog.Commando.SptCommands;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Dialog;
using SPTarkov.Server.Core.Models.Eft.Profile;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;

namespace WTTExampleMod.Commands;

[Injectable]
public class SixSevenPrestigeCommand(
    DatabaseServer databaseServer,
    MailSendService mailSendService,
    RewardHelper rewardHelper,
    ProfileHelper profileHelper) : ISptCommand
{
    public ValueTask<string> PerformAction(UserDialogInfo commandHandler, MongoId sessionId, SendMessageRequest request)
    {
        mailSendService.SendUserMessageToPlayer(sessionId, commandHandler, $"");
        var profile = profileHelper.GetFullProfile(sessionId);
        rewardHelper.AddAchievementToProfile(profile, "6948990c05f4f91bdb9a56f3");
        rewardHelper.AddAchievementToProfile(profile, "694c6575af08f6f1d59a5737");
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
            return "Usage: test 67prestige";
        }
    }
}