using System.Threading.Tasks;
using AutoMapper;
using Lykke.Logs;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.DomainServices;
using Moq;
using Xunit;

namespace MAVN.Service.PartnerApi.Tests.DomainServices
{
    public class BonusServiceTests
    {
        private readonly Mock<IPartnersIntegrationClient> _partnersIntegrationClientMock =
            new Mock<IPartnersIntegrationClient>();

        private readonly IBonusService _bonusService;

        public BonusServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile(3));
            });

            var mapper = mockMapper.CreateMapper();

            _bonusService = new BonusService(_partnersIntegrationClientMock.Object, mapper, EmptyLogFactory.Instance);
        }

        [Fact]
        public async Task When_Trigger_Bonus_To_Customers_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock.Setup(x =>
                x.BonusApi.TriggerBonusToCustomers(It
                    .IsAny<PartnersIntegration.Client.Models.BonusCustomersRequestModel>()));

            await _bonusService.TriggerBonusToCustomersAsync(
                It.IsAny<Domain.Models.Bonus.BonusCustomersRequestModel>());

            _partnersIntegrationClientMock.Verify(
                x => x.BonusApi.TriggerBonusToCustomers(
                    It.IsAny<PartnersIntegration.Client.Models.BonusCustomersRequestModel>()), Times.Once);
        }
    }
}
