namespace MAVN.Service.PartnerApi.Domain.Models.Referral
{
    /// <summary>
    /// Referral information request model
    /// </summary>
    public class ReferralInformationRequestModel
    {
        /// <summary>
        /// Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Partner id
        /// </summary>
        private string PartnerId;

        /// <summary>
        /// Location id
        /// </summary>
        public string LocationId { get; set; }

        public void SetPartnerId(string partnerId) => PartnerId = partnerId;

        public string GetPartnerId() => PartnerId;
    }
}
