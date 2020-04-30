namespace MAVN.Service.PartnerApi.Domain.Models.Message
{
    /// <summary>
    /// Represents send message request model
    /// </summary>
    public class SendMessageRequestModel
    {
        private string PartnerId;
            
        /// <summary>
        /// Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Location id
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Point of sale (POS) id
        /// </summary>
        public string PosId { get; set; }

        public string GetPartnerId() => PartnerId;

        public void SetPartnerId(string partnerId) => PartnerId = partnerId;
    }
}
