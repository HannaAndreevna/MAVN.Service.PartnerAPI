using Autofac;
using MAVN.Common.Middleware.Authentication;
using JetBrains.Annotations;
using MAVN.Service.MaintenanceMode.Client;
using MAVN.Service.PartnerManagement.Client;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.Sessions.Client;
using Lykke.SettingsReader;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.DomainServices;
using MAVN.Service.PartnerApi.Settings;
using MAVN.Service.PaymentManagement.Client;
using StackExchange.Redis;

namespace MAVN.Service.PartnerApi
{
    [UsedImplicitly]
    public class AutofacModule : Module
    {
        private readonly AppSettings _appSettings;

        public AutofacModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings.CurrentValue;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Services
            builder.RegisterType<RequestContext>()
                .As<IRequestContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LykkePrincipal>()
                .As<ILykkePrincipal>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthService>()
                .As<IAuthService>()
                .SingleInstance();

            builder.RegisterType<CustomerService>()
                .As<ICustomerService>()
                .SingleInstance();

            builder.RegisterType<BonusService>()
                .As<IBonusService>()
                .SingleInstance();

            builder.RegisterType<ReferralService>()
                .As<IReferralService>()
                .SingleInstance();

            builder.RegisterType<PaymentService>()
                .As<IPaymentService>()
                .SingleInstance();

            builder.RegisterType<MessageService>()
                .As<IMessageService>()
                .SingleInstance();

            builder.Register(c => ConnectionMultiplexer.Connect(_appSettings.PartnerApiService.CacheSettings.RedisConfiguration))
                .As<IConnectionMultiplexer>()
                .SingleInstance();

            // Clients
            builder.RegisterSessionsServiceClient(_appSettings.SessionsServiceClient);
            builder.RegisterPartnersIntegrationClient(_appSettings.PartnersIntegrationServiceClient, null);
            builder.RegisterPartnerManagementClient(_appSettings.PartnerManagementServiceClient, null);
            builder.RegisterMaintenanceModeClient(_appSettings.MaintenanceModeServiceClient, null);
            builder.RegisterPaymentManagementClient(_appSettings.PaymentManagementServiceClient, null);
        }
    }
}
