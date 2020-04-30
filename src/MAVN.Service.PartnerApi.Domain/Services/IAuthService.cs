using System.Threading.Tasks;

namespace MAVN.Service.PartnerApi.Domain.Services
{
    public interface IAuthService
    {
        Task<AuthResultModel> AuthAsync(string clientId, string clientSecret, string userInfo);
    }
}
