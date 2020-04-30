namespace MAVN.Service.PartnerApi.Domain.Models.Payment.Enums
{
    /// <summary>
    /// Represents get payment status
    /// </summary>
    public enum GetPaymentStatus
    {
        /// <summary>
        /// Not exist
        /// </summary>
        NotExist,

        /// <summary>
        /// Pending
        /// </summary>
        Pending,

        /// <summary>
        /// Executed
        /// </summary>
        Executed,

        /// <summary>
        /// Failed
        /// </summary>
        Failed
    }
}
