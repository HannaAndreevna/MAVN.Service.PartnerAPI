using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.PartnerApi.Domain.Models.Bonus;

namespace MAVN.Service.PartnerApi.Domain.Services
{
    public interface IBonusService
    {
        Task<List<BonusCustomerResponseModel>> TriggerBonusToCustomersAsync(BonusCustomersRequestModel model);
    }
}
