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
public class PreorderCommand(
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
        rewardHelper.AddAchievementToProfile(profile, "6948996f192a4d4fc09a56f7");
        return new ValueTask<string>(request.DialogId);
    }

    public string Command
    {
        get { return "preorderbonus"; }
    }

    public string CommandHelp
    {
        get
        {
            return "Usage: test preorderbonus";
        }
    }
}