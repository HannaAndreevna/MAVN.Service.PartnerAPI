using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.PartnerApi.Domain.Models.Bonus;
using MAVN.Service.PartnerApi.Domain.Services;

namespace MAVN.Service.PartnerApi.DomainServices
{
    public class BonusService : IBonusService
    {
        private readonly IPartnersIntegrationClient _partnersIntegrationClient;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public BonusService(IPartnersIntegrationClient partnersIntegrationClient, IMapper mapper,
            ILogFactory logFactory)
        {
            _partnersIntegrationClient = partnersIntegrationClient;
            _mapper = mapper;
            _log = logFactory.CreateLog(this);
        }

        public async Task<List<BonusCustomerResponseModel>> TriggerBonusToCustomersAsync(BonusCustomersRequestModel model)
        {
            var request = _mapper.Map<MAVN.Service.PartnersIntegration.Client.Models.BonusCustomersRequestModel>(model);

            var result = await _partnersIntegrationClient.BonusApi.TriggerBonusToCustomers(request);

            return _mapper.Map<List<BonusCustomerResponseModel>>(result);
        }
    }
}
