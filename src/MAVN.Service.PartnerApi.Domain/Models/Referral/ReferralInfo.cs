using MAVN.Service.PartnerApi.Domain.Models.Referral.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Referral
{
    /// <summary>
    /// referral info
    /// </summary>
    public class ReferralInfo
    {
        /// <summary>
        /// Referral id
        /// </summary>
        public string ReferralId { get; set; }

        /// <summary>
        /// Referrer email
        /// </summary>
        public string ReferrerEmail { get; set; }

        /// <summary>
        /// Referrer additional info
        /// </summary>
        public string ReferrerAdditionalInfo { get; set; }

        /// <summary>
        /// Status <see cref="ReferralStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ReferralStatus Status { get; set; }
    }
}
