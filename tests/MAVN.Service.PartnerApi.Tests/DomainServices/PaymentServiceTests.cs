using System.Threading.Tasks;
using AutoMapper;
using Lykke.Logs;
using Lykke.Service.PartnersIntegration.Client;
using Lykke.Service.PartnersIntegration.Client.Models;
using MAVN.Service.PartnerApi.Domain.Models.Payment;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.DomainServices;
using Moq;
using Xunit;

namespace MAVN.Service.PartnerApi.Tests.DomainServices
{
    public class PaymentServiceTests
    {
        private readonly Mock<IPartnersIntegrationClient> _partnersIntegrationClientMock =
            new Mock<IPartnersIntegrationClient>();

        private readonly IPaymentService _paymentService;

        public PaymentServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile(3));
            });

            var mapper = mockMapper.CreateMapper();

            _paymentService =
                new PaymentService(_partnersIntegrationClientMock.Object, mapper, EmptyLogFactory.Instance);
        }

        [Fact]
        public async Task When_Create_Payment_Request_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock.Setup(x =>
                x.PaymentsApi.CreatePaymentRequestAsync(It.IsAny<PaymentsCreateRequestModel>()));

            await _paymentService.CreatePaymentRequestAsync(It.IsAny<CreatePaymentRequestRequestModel>());

            _partnersIntegrationClientMock.Verify(
                x => x.PaymentsApi.CreatePaymentRequestAsync(It.IsAny<PaymentsCreateRequestModel>()), Times.Once);
        }

        [Fact]
        public async Task When_Get_Payment_Request_Status_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock.Setup(x =>
                x.PaymentsApi.GetPaymentRequestStatusAsync(It.IsAny<string>(), It.IsAny<string>()));

            await _paymentService.GetPaymentRequestStatusAsync(It.IsAny<string>(), It.IsAny<string>());

            _partnersIntegrationClientMock.Verify(
                x => x.PaymentsApi.GetPaymentRequestStatusAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_Cancel_Payment_Request_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock.Setup(x =>
                x.PaymentsApi.CancelPaymentRequestAsync(It.IsAny<string>(), It.IsAny<string>()));

            await _paymentService.CancelPaymentRequestAsync(It.IsAny<string>(), It.IsAny<string>());

            _partnersIntegrationClientMock.Verify(
                x => x.PaymentsApi.CancelPaymentRequestAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_Execute_Payment_Request_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock.Setup(x =>
                x.PaymentsApi.ExecutePaymentRequestAsync(It.IsAny<PaymentsExecuteRequestModel>()));

            await _paymentService.ExecutePaymentRequestAsync(It.IsAny<ExecutePaymentRequestRequestModel>());

            _partnersIntegrationClientMock.Verify(
                x => x.PaymentsApi.ExecutePaymentRequestAsync(It.IsAny<PaymentsExecuteRequestModel>()), Times.Once);
        }
    }
}
