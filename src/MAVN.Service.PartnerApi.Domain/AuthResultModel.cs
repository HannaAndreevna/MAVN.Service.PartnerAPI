using MAVN.Service.PartnerApi.Domain.Services;

namespace MAVN.Service.PartnerApi.Domain
{
    public class AuthResultModel
    {
        public string Token { get; set; }

        public ServicesError Error { get; set; }
    }
}
