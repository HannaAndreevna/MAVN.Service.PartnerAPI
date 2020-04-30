using JetBrains.Annotations;
using MAVN.Service.PartnerApi.Domain.Models.Payment.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Payment
{
    /// <summary>
    /// Represents create payments response
    /// </summary>
    [PublicAPI]
    public class CreatePaymentRequestResponseModel
    {
        /// <summary>
        /// Payment request id
        /// </summary>
        public string PaymentRequestId { get; set; }

        /// <summary>
        /// Payment request status, <see cref="CreatePaymentRequestStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CreatePaymentRequestStatus Status { get; set; }
    }
}
