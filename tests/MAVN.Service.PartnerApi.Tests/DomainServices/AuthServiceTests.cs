using System.Threading.Tasks;
using AutoMapper;
using Lykke.Logs;
using Lykke.Service.PartnerManagement.Client;
using Lykke.Service.PartnerManagement.Client.Models.Authentication;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.DomainServices;
using Moq;
using Xunit;

namespace MAVN.Service.PartnerApi.Tests.DomainServices
{
    public class AuthServiceTests
    {
        private readonly Mock<IPartnerManagementClient> _partnerManagementServiceServiceClientMock =
            new Mock<IPartnerManagementClient>();

        private readonly IAuthService _authService;

        public AuthServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile(3));
            });

            var mapper = mockMapper.CreateMapper();

            _authService = new AuthService(EmptyLogFactory.Instance, _partnerManagementServiceServiceClientMock.Object,
                mapper);
        }

        [Fact]
        public async Task When_Auth_Async_Is_Executed_Then_Partner_Management_Client_Is_Called()
        {
            _partnerManagementServiceServiceClientMock.Setup(x =>
                x.Auth.AuthenticateAsync(It.IsAny<AuthenticateRequestModel>()));

            var result = await _authService.AuthAsync("client id", "client secret", "user info");

            _partnerManagementServiceServiceClientMock.Verify(
                x => x.Auth.AuthenticateAsync(It.IsAny<AuthenticateRequestModel>()), Times.Once);
        }
    }
}
