using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.PartnersIntegration.Client;
using Lykke.Service.PartnersIntegration.Client.Models;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.DomainServices;
using Moq;
using Xunit;

namespace MAVN.Service.PartnerApi.Tests.DomainServices
{
    public class MessageServiceTests
    {
        private readonly Mock<IPartnersIntegrationClient> _partnersIntegrationClientMock =
            new Mock<IPartnersIntegrationClient>();

        private readonly IMessageService _messageService;

        public MessageServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfile(3)); });

            var mapper = mockMapper.CreateMapper();

            _messageService = new MessageService(_partnersIntegrationClientMock.Object, mapper);
        }

        [Fact]
        public async Task When_Send_Message_Async_Is_Executed_Then_Partners_Integration_Client_Is_Called()
        {
            _partnersIntegrationClientMock
                .Setup(x => x.MessagesApi.SendMessageAsync(It.IsAny<MessagesPostRequestModel>()))
                .Returns(Task.FromResult(It.IsAny<MessagesPostResponseModel>()));

            await _messageService.SendMessageAsync(It.IsAny<Domain.Models.Message.SendMessageRequestModel>());

            _partnersIntegrationClientMock.Verify(
                x => x.MessagesApi.SendMessageAsync(It.IsAny<MessagesPostRequestModel>()), Times.Once);
        }
    }
}
