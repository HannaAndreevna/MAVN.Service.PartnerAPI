using System.Threading.Tasks;
using MAVN.Service.PartnerApi.Domain.Models.Referral;

namespace MAVN.Service.PartnerApi.Domain.Services
{
    public interface IReferralService
    {
        Task<ReferralInformationResponseModel> GetReferralInformationAsync(ReferralInformationRequestModel model);
    }
}
