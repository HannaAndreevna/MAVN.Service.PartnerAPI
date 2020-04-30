using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace MAVN.Service.PartnerApi.Models.Payments
{
    /// <summary>
    /// Request model which is used for payment validation endpoint
    /// </summary>
    [PublicAPI]
    public class ValidatePaymentRequest
    {
        /// <summary>Payment request id</summary>
        [Required]
        public Guid PaymentRequestId { get; set; }

        /// <summary>Partner id</summary>
        [Required]
        public Guid PartnerId { get; set; }
    }
}
