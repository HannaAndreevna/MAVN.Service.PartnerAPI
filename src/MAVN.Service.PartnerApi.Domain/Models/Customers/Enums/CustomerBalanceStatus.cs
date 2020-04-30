namespace MAVN.Service.PartnerApi.Domain.Models.Customers.Enums
{
    /// <summary>
    /// Customer balance statsu
    /// </summary>
    public enum CustomerBalanceStatus
    {
        /// <summary>
        /// OK
        /// </summary>
        OK,

        /// <summary>
        /// Customer not found
        /// </summary>
        CustomerNotFound,

        /// <summary>
        /// Partner not found
        /// </summary>
        PartnerNotFound,

        /// <summary>
        /// Invalid currency
        /// </summary>
        InvalidCurrency
    }
}
