namespace MAVN.Service.PartnerApi.Domain.Models.Customers
{
    /// <summary>
    /// Customer balance request model
    /// </summary>
    public class CustomerBalanceRequestModel
    {
        private string PartnerId;

        /// <summary>
        /// Location id
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

        public void SetPartnerId(string partnerId) => PartnerId = partnerId;

        public string GetPartnerId() => PartnerId;
    }
}
