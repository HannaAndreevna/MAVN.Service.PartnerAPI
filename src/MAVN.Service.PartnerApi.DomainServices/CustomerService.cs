using System.Threading.Tasks;
using AutoMapper;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.PartnerApi.Domain.Models.Customers;
using MAVN.Service.PartnerApi.Domain.Services;

namespace MAVN.Service.PartnerApi.DomainServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IPartnersIntegrationClient _partnersIntegrationClient;
        private readonly IMapper _mapper;

        public CustomerService(
            IPartnersIntegrationClient partnersIntegrationClient,
            IMapper mapper)
        {
            _partnersIntegrationClient = partnersIntegrationClient;
            _mapper = mapper;
        }

        public async Task<CustomerBalanceResponseModel> GetCustomerBalanceAsync(string customerId, CustomerBalanceRequestModel model)
        {
            var request = _mapper.Map<PartnersIntegration.Client.Models.CustomerBalanceRequestModel>(model);

            var result = await _partnersIntegrationClient.CustomersApi.GetCustomerBalance(customerId, request);

            return _mapper.Map<CustomerBalanceResponseModel>(result);
        }

        public async Task<CustomerInformationResponseModel> QueryCustomerInformationAsync(QueryCustomerInformationRequestModel model)
        {
            var request = _mapper.Map<PartnersIntegration.Client.Models.CustomerInformationRequestModel>(model);

            var result = await _partnersIntegrationClient.CustomersApi.CustomerInformation(request);

            return _mapper.Map<CustomerInformationResponseModel>(result);
        }
    }
}
