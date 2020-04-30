namespace MAVN.Service.PartnerApi.Domain.Models.Customers
{
    /// <summary>
    /// Query customer information request model
    /// </summary>
    public class QueryCustomerInformationRequestModel
    {
        /// <summary>
        /// Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }
    }
}
