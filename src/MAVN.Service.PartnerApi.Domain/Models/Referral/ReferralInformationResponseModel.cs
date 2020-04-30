using System.Collections.Generic;
using MAVN.Service.PartnerApi.Domain.Models.Referral.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Referral
{
    public class ReferralInformationResponseModel
    {
        /// <summary>
        /// Referrals
        /// </summary>
        public IEnumerable<ReferralInfo> Referrals { get; set; }

        /// <summary>
        /// Status <see cref="ReferralInformationStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ReferralInformationStatus Status { get; set; }
    }
}
