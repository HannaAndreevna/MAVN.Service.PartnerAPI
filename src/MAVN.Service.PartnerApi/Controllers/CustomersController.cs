using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Common;
using Common.Log;
using MAVN.Common.Middleware.Authentication;
using Lykke.Common.ApiLibrary.Exceptions;
using Lykke.Common.Log;
using MAVN.Service.PartnerApi.Domain.Models.Customers;
using MAVN.Service.PartnerApi.Domain.Services;
using MAVN.Service.PartnerApi.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;
using CustomerBalanceRequestModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerBalanceRequestModel;
using CustomerBalanceResponseModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerBalanceResponseModel;
using CustomerInformationResponseModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerInformationResponseModel;

namespace MAVN.Service.PartnerApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [LykkeAuthorize]
    public class CustomersController : Controller
    {
        private readonly ILog _log;
        private readonly ICustomerService _customerService;
        private readonly IRequestContext _requestContext;

        public CustomersController(
            ICustomerService customerService,
            IRequestContext requestContext,
            ILogFactory logFactory)
        {
            _customerService = customerService;
            _requestContext = requestContext;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Return customer balance data
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <param name="model"><see cref="CustomerBalanceRequestModel"/></param>
        /// <returns><see cref="CustomerBalanceResponseModel"/></returns>
        [HttpGet("/api/balance/query")]
        [ProducesResponseType(typeof(CustomerBalanceResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<CustomerBalanceResponseModel> GetCustomerBalanceAsync(
            [FromQuery] [Required] string customerId,
            [FromQuery] CustomerBalanceRequestModel model)
        {
            if (string.IsNullOrEmpty(customerId))
                throw LykkeApiErrorException.BadRequest(ApiErrorCodes.Service.CustomerIdEmpty);

            if (customerId.Length < 1 || customerId.Length > 100)
                throw LykkeApiErrorException.BadRequest(ApiErrorCodes.Service.CustomerIdInvalidLength);

            model.SetPartnerId(_requestContext.UserId);

            _log.Info("Get customer balance started", new { customerId, customer = model });

            var result = await _customerService.GetCustomerBalanceAsync(customerId, model);

            _log.Info("Get customer balance finished", new { customerId, customer = model });

            return result;
        }

        /// <summary>
        /// Returns customer data
        /// </summary>
        /// <param name="model"><see cref="QueryCustomerInformationRequestModel"/></param>
        /// <returns><see cref="CustomerInformationResponseModel"/></returns>
        [HttpPost("query")]
        [ProducesResponseType(typeof(CustomerInformationResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<CustomerInformationResponseModel> QueryCustomerInformationAsync(
            [FromBody] QueryCustomerInformationRequestModel model)
        {
            var sanitizedModel = new { model.CustomerId, Email = model.Email.SanitizeEmail(), Phone = model.Phone.SanitizePhone() };

            _log.Info("Get customer information started", sanitizedModel);

            var result = await _customerService.QueryCustomerInformationAsync(model);

            _log.Info("Get customer information finished", sanitizedModel);

            return result;
        }
    }
}
