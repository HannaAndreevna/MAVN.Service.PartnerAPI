using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Service.PartnersIntegration.Client;
using MAVN.Service.PartnerApi.Domain.Models.Referral;
using MAVN.Service.PartnerApi.Domain.Services;

namespace MAVN.Service.PartnerApi.DomainServices
{
    public class ReferralService : IReferralService
    {
        private readonly IPartnersIntegrationClient _partnersIntegrationClient;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public ReferralService(IPartnersIntegrationClient partnersIntegrationClient, IMapper mapper,
            ILogFactory logFactory)
        {
            _partnersIntegrationClient = partnersIntegrationClient;
            _mapper = mapper;
            _log = logFactory.CreateLog(this);
        }

        public async Task<ReferralInformationResponseModel> GetReferralInformationAsync(ReferralInformationRequestModel model)
        {
            var request = _mapper.Map<MAVN.Service.PartnersIntegration.Client.Models.ReferralInformationRequestModel>(model);

            var result = await _partnersIntegrationClient.ReferralsApi.ReferralInformation(request);

            return _mapper.Map<ReferralInformationResponseModel>(result);
        }
    }
}
