using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using MAVN.Common.Middleware.Authentication;
using Lykke.Common.Log;
using MAVN.Service.PartnerApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using ReferralInformationRequestModel = MAVN.Service.PartnerApi.Domain.Models.Referral.ReferralInformationRequestModel;
using ReferralInformationResponseModel = MAVN.Service.PartnerApi.Domain.Models.Referral.ReferralInformationResponseModel;

namespace MAVN.Service.PartnerApi.Controllers
{
    [Route("api/referrals")]
    [ApiController]
    [LykkeAuthorize]
    public class ReferralsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILog _log;
        private readonly IReferralService _referralService;
        private readonly IRequestContext _requestContext;

        public ReferralsController(IMapper mapper, ILogFactory logFactory, IReferralService referralService,
            IRequestContext requestContext)
        {
            _mapper = mapper;
            _referralService = referralService;
            _requestContext = requestContext;
            _log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Get referral information
        /// </summary>
        /// <param name="model"><see cref="ReferralInformationRequestModel"/></param>
        /// <returns><see cref="ReferralInformationResponseModel"/></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ReferralInformationResponseModel), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<ReferralInformationResponseModel> GetReferralInformationAsync(
            [FromQuery] ReferralInformationRequestModel model)
        {
            model.SetPartnerId(_requestContext.UserId);

            var sanitizedModel = new { model.CustomerId, model.LocationId, PartnerId = model.GetPartnerId() };

            _log.Info("Get referral information started", sanitizedModel);

            var result = await _referralService.GetReferralInformationAsync(model);

            _log.Info("Get referral information finished", sanitizedModel);

            return result;
        }
    }
}
