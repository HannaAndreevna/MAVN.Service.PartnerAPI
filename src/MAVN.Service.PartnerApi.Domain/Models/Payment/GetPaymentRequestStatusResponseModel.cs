using System;
using JetBrains.Annotations;
using MAVN.Service.PartnerApi.Domain.Models.Payment.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Payment
{
    /// <summary>
    /// Represent get payment request status model
    /// </summary>
    [PublicAPI]
    public class GetPaymentRequestStatusResponseModel
    {
        /// <summary>
        /// Payment request status, <see cref="GetPaymentRequestStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GetPaymentRequestStatus Status { get; set; }

        /// <summary>
        /// Total Fiat amount
        /// </summary>
        public string TotalFiatAmount { get; set; }

        /// <summary>
        /// FIAT amount
        /// </summary>
        public string FiatAmount { get; set; }

        /// <summary>
        /// FIAT currency
        /// </summary>
        public string FiatCurrency { get; set; }

        /// <summary>
        /// Tokens amount
        /// </summary>
        public string TokensAmount { get; set; }

        /// <summary>
        /// Payment request timestamp
        /// </summary>
        public DateTime PaymentRequestTimestamp { get; set; }

        /// <summary>
        /// Payment request customer expiration timestamp
        /// </summary>
        public DateTime PaymentRequestCustomerExpirationTimestamp { get; set; }
        
        /// <summary>
        /// Payment execution timestamp
        /// </summary>
        public DateTime? PaymentExecutionTimestamp { get; set; }
        
        /// <summary>
        /// Payment request approved timestamp
        /// </summary>
        public DateTime PaymentRequestApprovedTimestamp { get; set; }
    }
}
