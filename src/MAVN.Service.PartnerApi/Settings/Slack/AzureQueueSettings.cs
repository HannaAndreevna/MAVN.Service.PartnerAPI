using JetBrains.Annotations;

namespace MAVN.Service.PartnerApi.Settings.Slack
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AzureQueueSettings
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }
    }
}
