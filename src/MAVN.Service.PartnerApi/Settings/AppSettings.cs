using JetBrains.Annotations;
using MAVN.Service.MaintenanceMode.Client;
using MAVN.Service.PartnerManagement.Client;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.Sessions.Client;
using MAVN.Service.PartnerApi.Settings.Clients;
using MAVN.Service.PartnerApi.Settings.Service;
using MAVN.Service.PartnerApi.Settings.Slack;
using MAVN.Service.PaymentManagement.Client;

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

        public PaymentManagementServiceClientSettings PaymentManagementServiceClient { get; set; }
    }
}
