using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Log;
using MAVN.Common.Middleware.Authentication;
using Lykke.Common.Log;
using MAVN.Service.PartnerApi.Domain.Models.Bonus;
using MAVN.Service.PartnerApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.PartnerApi.Controllers
{
    [Route("api/bonus")]
    [ApiController]
    [LykkeAuthorize]
    public class BonusController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILog _log;
        private readonly IBonusService _bonusService;
        private readonly IRequestContext _requestContext;

        public BonusController(IMapper mapper, ILogFactory logFactory, IBonusService bonusService,
            IRequestContext requestContext)
        {
            _mapper = mapper;
            _bonusService = bonusService;
            _requestContext = requestContext;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Triggers bonus to a customer
        /// </summary>
        /// <param name="model"><see cref="BonusCustomersRequestModel"/></param>
        /// <returns><see cref="BonusCustomerResponseModel"/></returns>
        [HttpPost("customers")]
        [ProducesResponseType(typeof(List<BonusCustomerResponseModel>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<List<BonusCustomerResponseModel>> TriggerBonusToCustomersAsync(
            [FromBody] BonusCustomersRequestModel model)
        {
            var partnerId = _requestContext.UserId;

            model.BonusCustomers.ForEach(x => x.SetPartnerId(partnerId));

            var sanitizedModel = model.BonusCustomers.Select(x => new
            {
                x.CustomerId,
                Email = x.Email.SanitizeEmail(),
                x.Currency,
                x.FiatAmount,
                x.LocationId,
                PartnerId = x.GetPartnerId(),
                x.PaymentTimestamp,
                x.PosId
            }).ToList();

            _log.Info("Trigger bonus to customers started", sanitizedModel);

            var result = await _bonusService.TriggerBonusToCustomersAsync(model);

            _log.Info("Trigger bonus to customers finished", sanitizedModel);

            return result;
        }
    }
}
