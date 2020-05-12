using MAVN.Numerics;
using JetBrains.Annotations;

namespace MAVN.Service.PartnerApi.Domain.Models.Payment
{
    /// <summary>
    /// Represents create payments request 
    /// </summary>
    [PublicAPI]
    public class CreatePaymentRequestRequestModel
    {
        /// <summary>
        /// Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// The total payment amount in fiat 
        /// </summary>
        public string TotalFiatAmount { get; set; }

        /// <summary>
        /// FIAT amount
        /// </summary>
        public string FiatAmount { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Tokens amount
        /// </summary>
        public Money18? TokensAmount { get; set; }

        /// <summary>
        /// Additional information about the payment. Will be shown to customer
        /// </summary>
        public string PaymentInfo { get; set; }

        /// <summary>
        /// Partner id
        /// </summary>
        private string PartnerId;

        /// <summary>
        /// Hotel/location id
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Point of sale (POS) id
        /// </summary>
        public string PosId { get; set; }

        /// <summary>
        /// Url that will be used to notify that payment was processed
        /// </summary>
        public string PaymentProcessedCallbackUrl { get; set; }

        /// <summary>
        /// Expiration timeout in seconds
        /// </summary>
        public int? ExpirationTimeoutInSeconds { get; set; }

        /// <summary>
        /// Authentication token to be used with payment processed callback url
        /// </summary>
        private string RequestAuthToken;

        public void SetPartnerId(string partnerId) => PartnerId = partnerId;

        public string GetPartnerId() => PartnerId;

        public string GetRequestAuthToken() => RequestAuthToken;

        public void SetRequestAuthToken(string token) => RequestAuthToken = token;
    }
}
