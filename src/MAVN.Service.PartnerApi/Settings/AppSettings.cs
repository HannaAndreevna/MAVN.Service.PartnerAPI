using JetBrains.Annotations;
using Lykke.Service.MaintenanceMode.Client;
using Lykke.Service.PartnerManagement.Client;
using Lykke.Service.PartnersIntegration.Client;
using Lykke.Service.Sessions.Client;
using MAVN.Service.PartnerApi.Settings.Clients;
using MAVN.Service.PartnerApi.Settings.Service;
using MAVN.Service.PartnerApi.Settings.Slack;

namespace MAVN.Service.PartnerApi.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings
    {
        public PartnerApiSettings PartnerApiService { get; set; }

        public SessionsServiceClientSettings SessionsServiceClient { get; set; }

        public SlackNotificationsSettings SlackNotifications { get; set; }

        public MonitoringServiceClientSettings MonitoringServiceClient { get; set; }

        public PartnersIntegrationServiceClientSettings PartnersIntegrationServiceClient { get; set; }

        public PartnerManagementServiceClientSettings PartnerManagementServiceClient { get; set; }

        public MaintenanceModeServiceClientSettings MaintenanceModeServiceClient { get; set; }
    }
}
