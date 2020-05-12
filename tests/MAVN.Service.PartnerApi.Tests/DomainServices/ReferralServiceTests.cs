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
    public class ReferralServiceTests
    {
        private readonly Mock<IPartnersIntegrationClient> _partnersIntegrationClientMock =
            new Mock<IPartnersIntegrationClient>();

        private readonly IReferralService _referralService;

        public ReferralServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile(3));
            });

            var mapper = mockMapper.CreateMapper();

            _referralService =
                new ReferralService(_partnersIntegrationClientMock.Object, mapper, EmptyLogFactory.Instance);
        }

        [Fact]
        public async Task When_Get_Referral_Information_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock.Setup(x =>
                x.ReferralsApi.ReferralInformation(It
                    .IsAny<PartnersIntegration.Client.Models.ReferralInformationRequestModel>()));

            await _referralService.GetReferralInformationAsync(
                It.IsAny<Domain.Models.Referral.ReferralInformationRequestModel>());

            _partnersIntegrationClientMock.Verify(
                x => x.ReferralsApi.ReferralInformation(
                    It.IsAny<PartnersIntegration.Client.Models.ReferralInformationRequestModel>()), Times.Once);
        }
    }
}
