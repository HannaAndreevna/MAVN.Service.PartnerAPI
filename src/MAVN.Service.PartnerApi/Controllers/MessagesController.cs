using System.Net;
using System.Threading.Tasks;
using Common.Log;
using MAVN.Common.Middleware.Authentication;
using Lykke.Common.Log;
using MAVN.Service.PartnerApi.Domain.Models.Message;
using MAVN.Service.PartnerApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.PartnerApi.Controllers
{
    [Route("api/messages")]
    [ApiController]
    [LykkeAuthorize]
    public class MessagesController : Controller
    {
        private readonly ILog _log;
        private readonly IMessageService _messageService;
        private readonly IRequestContext _requestContext;

        public MessagesController(ILogFactory logFactory, IMessageService messageService,
            IRequestContext requestContext)
        {
            _messageService = messageService;
            _requestContext = requestContext;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Send partner message
        /// </summary>
        /// <param name="model"><see cref="SendMessageRequestModel"/></param>
        /// <returns><see cref="SendMessageResponseModel"/></returns>
        [HttpPost]
        [ProducesResponseType(typeof(SendMessageResponseModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<SendMessageResponseModel> SendMessageAsync([FromBody] SendMessageRequestModel model)
        {
            _log.Info("Send message started", new {model.LocationId, model.CustomerId, model.PosId, model.Subject});

            var partnerId = _requestContext.UserId;

            model.SetPartnerId(partnerId);

            var result = await _messageService.SendMessageAsync(model);

            var logContext = new
            {
                model.LocationId,
                model.CustomerId,
                model.PosId,
                result.Status,
                PartnerMessageId = string.IsNullOrEmpty(result.PartnerMessageId) ? string.Empty : result.PartnerMessageId
            };

            _log.Info("Send message finished", logContext);

            return result;
        }
    }
}
