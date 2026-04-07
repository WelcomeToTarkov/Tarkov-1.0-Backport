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
public class EndingsCommand(
    MailSendService mailSendService,
    RewardHelper rewardHelper,
    ProfileHelper profileHelper) : ISptCommand
{
    public ValueTask<string> PerformAction(UserDialogInfo commandHandler, MongoId sessionId, SendMessageRequest request)
    {
        IEnumerable<MongoId> endingbackgrounds = new MongoId[]
        {
            "68fb63be323974a4ae011df8",
            "68fb638ebe7aff394b016818",
            "68fb63afc09c82a74d07d21f",
            "68fb63c9be7aff394b01681a",
        };
        var profile = profileHelper.GetFullProfile(sessionId);
        profile.AddCustomisations(endingbackgrounds, "environment", CustomisationSource.DEFAULT);
        rewardHelper.AddAchievementToProfile(profile, "694c60b50cb1e6ad639a5723");
        rewardHelper.AddAchievementToProfile(profile, "6948990c05f4f91bdb9a56f3");
        return new ValueTask<string>(request.DialogId);
    }

    public string Command
    {
        get { return "ibeatthegameiswear"; }
    }

    public string CommandHelp
    {
        get
        {
            return "Usage: Receive all four endings customizations (dogtags, hideout, main menu environments, etc)";
        }
    }
}