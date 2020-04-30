using System.Threading.Tasks;
using MAVN.Service.PartnerApi.Domain.Models.Customers;

namespace MAVN.Service.PartnerApi.Domain.Services
{
    public interface ICustomerService
    {
        Task<CustomerBalanceResponseModel> GetCustomerBalanceAsync(string customerId, CustomerBalanceRequestModel model);

        Task<CustomerInformationResponseModel> QueryCustomerInformationAsync(QueryCustomerInformationRequestModel model);
    }
}
