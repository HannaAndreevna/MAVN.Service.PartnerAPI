using JetBrains.Annotations;
using MAVN.Service.PartnerApi.Domain.Models.Payment.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Payment
{
    /// <summary>
    /// Represent execute payment request response
    /// </summary>
    [PublicAPI]
    public class ExecutePaymentRequestResponseModel
    {
        /// <summary>
        /// Execute payment request status, <see cref="ExecutePaymentRequestStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ExecutePaymentRequestStatus Status { get; set; }

        /// <summary>
        /// Payment id
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Tokens amount
        /// </summary>
        public string TokensAmount { get; set; }

        /// <summary>
        /// FIAT amount
        /// </summary>
        public string FiatAmount { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }
    }
}
