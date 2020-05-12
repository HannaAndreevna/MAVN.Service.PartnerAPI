using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.PartnerApi.Domain.Models.Payment;
using MAVN.Service.PartnerApi.Domain.Services;

namespace MAVN.Service.PartnerApi.DomainServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IPartnersIntegrationClient _partnersIntegrationClient;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public PaymentService(IPartnersIntegrationClient partnersIntegrationClient, IMapper mapper,
            ILogFactory logFactory)
        {
            _partnersIntegrationClient = partnersIntegrationClient;
            _mapper = mapper;
            _log = logFactory.CreateLog(this);
        }

        public async Task<CreatePaymentRequestResponseModel> CreatePaymentRequestAsync(
            CreatePaymentRequestRequestModel model)
        {
            var request = _mapper.Map<PartnersIntegration.Client.Models.PaymentsCreateRequestModel>(model);

            var result = await _partnersIntegrationClient.PaymentsApi.CreatePaymentRequestAsync(request);

            return _mapper.Map<CreatePaymentRequestResponseModel>(result);
        }

        public async Task<GetPaymentRequestStatusResponseModel> GetPaymentRequestStatusAsync(string paymentRequestId,
            string partnerId)
        {
            var result =
                await _partnersIntegrationClient.PaymentsApi.GetPaymentRequestStatusAsync(paymentRequestId, partnerId);

            return _mapper.Map<GetPaymentRequestStatusResponseModel>(result);
        }

        public async Task CancelPaymentRequestAsync(string paymentRequestId, string partnerId)
        {
            await _partnersIntegrationClient.PaymentsApi.CancelPaymentRequestAsync(paymentRequestId, partnerId);
        }

        public async Task<ExecutePaymentRequestResponseModel> ExecutePaymentRequestAsync(
            ExecutePaymentRequestRequestModel model)
        {
            var request = _mapper.Map<PartnersIntegration.Client.Models.PaymentsExecuteRequestModel>(model);

            var result = await _partnersIntegrationClient.PaymentsApi.ExecutePaymentRequestAsync(request);

            return _mapper.Map<ExecutePaymentRequestResponseModel>(result);
        }
    }
}
