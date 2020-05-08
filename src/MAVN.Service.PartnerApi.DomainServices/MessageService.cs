using System.Threading.Tasks;
using AutoMapper;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.PartnerApi.Domain.Models.Message;
using MAVN.Service.PartnerApi.Domain.Services;

namespace MAVN.Service.PartnerApi.DomainServices
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IPartnersIntegrationClient _partnersIntegrationClient;

        public MessageService(IPartnersIntegrationClient partnersIntegrationClient, IMapper mapper)
        {
            _partnersIntegrationClient = partnersIntegrationClient;
            _mapper = mapper;
        }

        public async Task<SendMessageResponseModel> SendMessageAsync(SendMessageRequestModel model)
        {
            var request = _mapper.Map<MAVN.Service.PartnersIntegration.Client.Models.MessagesPostRequestModel>(model);

            var result = await _partnersIntegrationClient.MessagesApi.SendMessageAsync(request);

            return _mapper.Map<SendMessageResponseModel>(result);
        }
    }
}
