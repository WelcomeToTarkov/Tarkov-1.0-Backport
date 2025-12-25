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

namespace WTTExampleMod.Commands;

[Injectable]
public class TwitchGuyCommand(
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
        rewardHelper.AddAchievementToProfile(profile, "694d58833cff7ff7be31c5e8");
        return new ValueTask<string>(request.DialogId);
    }

    public string Command
    {
        get { return "twitchguytwitchguytwitchguy"; }
    }

    public string CommandHelp
    {
        get
        {
            return "Usage: test twitchguytwitchguytwitchguy";
        }
    }
}