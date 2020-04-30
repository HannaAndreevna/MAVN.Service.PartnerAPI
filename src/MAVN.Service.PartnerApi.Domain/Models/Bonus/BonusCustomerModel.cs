using System;

namespace MAVN.Service.PartnerApi.Domain.Models.Bonus
{
    public class BonusCustomerModel
    {
        public string CustomerId { get; set; }

        public string Email { get; set; }

        public string FiatAmount { get; set; }

        public string Currency { get; set; }

        public DateTime? PaymentTimestamp { get; set; }

        private string PartnerId;

        public string LocationId { get; set; }

        public string PosId { get; set; }

        public void SetPartnerId(string partnerId) => PartnerId = partnerId;

        public string GetPartnerId() => PartnerId;
    }
}
