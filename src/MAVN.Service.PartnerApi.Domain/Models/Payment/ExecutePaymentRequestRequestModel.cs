using JetBrains.Annotations;

namespace MAVN.Service.PartnerApi.Domain.Models.Payment
{
    /// <summary>
    /// Represents execute payment
    /// </summary>
    [PublicAPI]
    public class ExecutePaymentRequestRequestModel
    {
        /// <summary>
        /// Payment request id
        /// </summary>
        public string PaymentRequestId { get; set; }

        /// <summary>
        /// Partner id
        /// </summary>
        private string PartnerId;

        public void SetPartnerId(string partnerId) => PartnerId = partnerId;

        public string GetPartnerId() => PartnerId;
    }
}
