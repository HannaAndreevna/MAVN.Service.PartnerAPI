using System.Threading.Tasks;
using MAVN.Service.PartnerApi.Domain.Models.Message;

namespace MAVN.Service.PartnerApi.Domain.Services
{
    public interface IMessageService
    {
        Task<SendMessageResponseModel> SendMessageAsync(SendMessageRequestModel model);
    }
}
