using JetBrains.Annotations;

namespace MAVN.Service.PartnerApi.Settings.Slack
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SlackNotificationsSettings
    {
        public AzureQueueSettings AzureQueue { get; set; }
    }
}
