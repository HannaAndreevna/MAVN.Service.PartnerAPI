using System.Threading.Tasks;
using MAVN.Service.PartnerApi.Domain.Models.Payment;

namespace MAVN.Service.PartnerApi.Domain.Services
{
    public interface IPaymentService
    {
        Task<CreatePaymentRequestResponseModel> CreatePaymentRequestAsync(CreatePaymentRequestRequestModel model);

        Task<GetPaymentRequestStatusResponseModel> GetPaymentRequestStatusAsync(string paymentRequestId,
            string partnerId);

        Task CancelPaymentRequestAsync(string paymentRequestId, string partnerId);

        Task<ExecutePaymentRequestResponseModel> ExecutePaymentRequestAsync(ExecutePaymentRequestRequestModel model);
    }
}
