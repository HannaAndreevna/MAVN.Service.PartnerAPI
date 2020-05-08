using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Service.PartnerManagement.Client;
using MAVN.Service.PartnerManagement.Client.Models.Authentication;
using MAVN.Service.PartnerApi.Domain;
using MAVN.Service.PartnerApi.Domain.Services;

namespace MAVN.Service.PartnerApi.DomainServices
{
    public class AuthService : IAuthService
    {
        private readonly ILog _log;
        private readonly IPartnerManagementClient _partnerManagementServiceServiceClient;
        private readonly IMapper _mapper;

        public AuthService(ILogFactory logFactory, IPartnerManagementClient partnerManagementServiceClient,
            IMapper mapper)
        {
            _partnerManagementServiceServiceClient = partnerManagementServiceClient;
            _mapper = mapper;
            _log = logFactory.CreateLog(this);
        }

        public async Task<AuthResultModel> AuthAsync(string clientId, string clientSecret, string userInfo)
        {
            var result =
                await _partnerManagementServiceServiceClient.Auth.AuthenticateAsync(new AuthenticateRequestModel
                {
                    ClientId = clientId, ClientSecret = clientSecret, UserInfo = userInfo
                });

            return _mapper.Map<AuthResultModel>(result);
        }
    }
}
