using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Falcon.Common.Middleware.Authentication;
using Lykke.Common.Log;
using MAVN.Service.PartnerApi.Domain.Models.Payment;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.Models.Payments;
using MAVN.Service.PaymentManagement.Client;
using MAVN.Service.PaymentManagement.Client.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.PartnerApi.Controllers
{
    [Route("api/payments")]
    [ApiController]
    [LykkeAuthorize]
    public class PaymentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILog _log;
        private readonly IPaymentService _paymentService;
        private readonly IPaymentManagementClient _paymentManagementClient;
        private readonly IRequestContext _requestContext;

        public PaymentsController(
            IMapper mapper,
            ILogFactory logFactory,
            IPaymentService paymentService,
            IPaymentManagementClient paymentManagementClient,
            IRequestContext requestContext)
        {
            _mapper = mapper;
            _paymentService = paymentService;
            _paymentManagementClient = paymentManagementClient;
            _requestContext = requestContext;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Create payment request
        /// </summary>
        /// <param name="model"><see cref="CreatePaymentRequestRequestModel"/></param>
        /// <returns><see cref="CreatePaymentRequestResponseModel"/></returns>
        [HttpPost("requests")]
        [ProducesResponseType(typeof(CreatePaymentRequestResponseModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<CreatePaymentRequestResponseModel> CreatePaymentRequestAsync(
            [FromBody] CreatePaymentRequestRequestModel model)
        {
            model.SetPartnerId(_requestContext.UserId);
            model.SetRequestAuthToken(_requestContext.SessionToken);

            var sanitizedModel = new
            {
                model.TokensAmount,
                model.Currency,
                model.CustomerId,
                model.FiatAmount,
                model.LocationId,
                model.PaymentInfo,
                model.PosId,
                model.TotalFiatAmount,
                PartnerId = model.GetPartnerId()
            };

            _log.Info("Create payment request started", sanitizedModel);

            var result = await _paymentService.CreatePaymentRequestAsync(model);

            _log.Info("Create payment request finished", sanitizedModel);

            return result;
        }

        /// <summary>
        /// Get payment request status
        /// </summary>
        /// <param name="paymentRequestId">Payment request id</param>
        /// <returns><see cref="GetPaymentRequestStatusResponseModel"/></returns>
        [HttpGet("requests")]
        [ProducesResponseType(typeof(GetPaymentRequestStatusResponseModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<GetPaymentRequestStatusResponseModel> GetPaymentRequestStatusAsync(
            [FromQuery] [Required] string paymentRequestId)
        {
            var partnerId = _requestContext.UserId;

            _log.Info("Get payment request status started", new {paymentRequestId, partnerId});

            var result = await _paymentService.GetPaymentRequestStatusAsync(paymentRequestId, partnerId);

            _log.Info("Get payment request status finished", new {paymentRequestId, partnerId});

            return result;
        }

        /// <summary>
        /// Cancel payment request
        /// </summary>
        /// <param name="paymentRequestId">Payment request id</param>
        /// <returns></returns>
        [HttpDelete("requests")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CancelPaymentRequestAsync([FromQuery] [Required] string paymentRequestId)
        {
            var partnerId = _requestContext.UserId;

            _log.Info("Cancel payment request status started", new {paymentRequestId, partnerId});

            await _paymentService.CancelPaymentRequestAsync(paymentRequestId, partnerId);

            _log.Info("Cancel payment request status finished", new {paymentRequestId, partnerId});

            return NoContent();
        }

        /// <summary>
        /// Execute payment request
        /// </summary>
        /// <param name="model"><see cref="ExecutePaymentRequestRequestModel"/></param>
        /// <returns><see cref="ExecutePaymentRequestResponseModel"/></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ExecutePaymentRequestResponseModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<ExecutePaymentRequestResponseModel> ExecutePaymentRequestAsync(
            [FromBody] ExecutePaymentRequestRequestModel model)
        {
            model.SetPartnerId(_requestContext.UserId);

            var sanitizedModel = new
            {
                model.PaymentRequestId,
                PartnerId = model.GetPartnerId()
            };

            _log.Info("Execute payment request started", sanitizedModel);

            var result = await _paymentService.ExecutePaymentRequestAsync(model);

            _log.Info("Execute payment request finished", sanitizedModel);

            return result;
        }

        /// <summary>
        /// Validate Payment
        /// </summary>
        /// <param name="request"><see cref="ValidatePaymentRequest"/></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task ValidatePaymentAsync([FromBody] ValidatePaymentRequest request)
        {
            await _paymentManagementClient.Api.ValidatePaymentAsync(new PaymentValidationRequest
            {
                PartnerId = request.PartnerId, PaymentRequestId = request.PaymentRequestId
            });
        }
    }
}
