using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.PartnersIntegration.Client;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.DomainServices;
using Moq;
using Xunit;

namespace MAVN.Service.PartnerApi.Tests.DomainServices
{
    public class CustomerServiceTests
    {
        private readonly Mock<IPartnersIntegrationClient> _partnersIntegrationClientMock =
            new Mock<IPartnersIntegrationClient>();

        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile(3));
            });

            var mapper = mockMapper.CreateMapper();

            _customerService = new CustomerService(_partnersIntegrationClientMock.Object, mapper);
        }

        [Fact]
        public async Task When_Get_Customer_Balance_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock.Setup(x =>
                x.CustomersApi.GetCustomerBalance(It.IsAny<string>(),
                    It.IsAny<Lykke.Service.PartnersIntegration.Client.Models.CustomerBalanceRequestModel>()));

            await _customerService.GetCustomerBalanceAsync(It.IsAny<string>(),
                It.IsAny<Domain.Models.Customers.CustomerBalanceRequestModel>());

            _partnersIntegrationClientMock.Verify(
                x => x.CustomersApi.GetCustomerBalance(It.IsAny<string>(),
                    It.IsAny<Lykke.Service.PartnersIntegration.Client.Models.CustomerBalanceRequestModel>()), Times.Once);
        }
    }
}
