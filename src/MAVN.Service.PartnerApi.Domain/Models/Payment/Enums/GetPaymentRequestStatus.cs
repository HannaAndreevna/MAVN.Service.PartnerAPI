namespace MAVN.Service.PartnerApi.Domain.Models.Payment.Enums
{
    /// <summary>
    /// Represents payment request status
    /// </summary>
    public enum GetPaymentRequestStatus
    {
        /// <summary>
        /// Payment request not found
        /// </summary>
        PaymentRequestNotFound,

        /// <summary>
        /// Pending customer confirmation
        /// </summary>
        PendingCustomerConfirmation,

        /// <summary>
        /// Rejected by customer
        /// </summary>
        RejectedByCustomer,

        /// <summary>
        /// Pending partner confirmation
        /// </summary>
        PendingPartnerConfirmation,

        /// <summary>
        /// Cancelled by partner
        /// </summary>
        CancelledByPartner,

        /// <summary>
        /// Payment executed
        /// </summary>
        PaymentExecuted,

        /// <summary>
        /// Operation failed
        /// </summary>
        OperationFailed,

        /// <summary>
        /// Request expired
        /// </summary>
        RequestExpired,

        /// <summary>
        /// Payment expired
        /// </summary>
        PaymentExpired
    }
}
