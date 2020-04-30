using MAVN.Service.PartnerApi.Domain.Models.Bonus.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Bonus
{
    public class BonusCustomerResponseModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BonusCustomerStatus CustomerStatus { get; set; }

        public string CustomerId { get; set; }

        public string CustomerEmail { get; set; }

        public int BonusCustomerSeqNumber { get; set; }
    }
}
