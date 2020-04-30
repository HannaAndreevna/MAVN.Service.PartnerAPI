namespace MAVN.Service.PartnerApi.Domain.Models.Payment.Enums
{
    /// <summary>
    /// represent execute payment request status
    /// </summary>
    public enum ExecutePaymentRequestStatus
    {
        /// <summary>
        /// Ok
        /// </summary>
        OK,

        /// <summary>
        /// Payment request not found
        /// </summary>
        PaymentRequestNotFound,

        /// <summary>
        /// Payment request not valid
        /// </summary>
        PaymentRequestNotValid
    }
}
