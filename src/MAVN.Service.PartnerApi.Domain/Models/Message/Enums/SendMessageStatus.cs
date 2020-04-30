namespace MAVN.Service.PartnerApi.Domain.Models.Message.Enums
{
    /// <summary>
    /// Send message error code
    /// </summary>
    public enum SendMessageStatus
    {
        /// <summary>
        /// Ok
        /// </summary>
        OK,

        /// <summary>
        /// Customer not found
        /// </summary>
        CustomerNotFound,

        /// <summary>
        /// Customer is blocked
        /// </summary>
        CustomerIsBlocked,

        /// <summary>
        /// Partner not found
        /// </summary>
        PartnerNotFound,

        /// <summary>
        /// Location not found
        /// </summary>
        LocationNotFound
    }
}
