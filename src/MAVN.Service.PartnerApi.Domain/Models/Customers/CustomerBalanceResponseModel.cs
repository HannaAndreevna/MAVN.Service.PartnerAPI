using MAVN.Service.PartnerApi.Domain.Models.Customers.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Customers
{
    /// <summary>
    /// Customer balance response model
    /// </summary>
    public class CustomerBalanceResponseModel
    {
        /// <summary>
        /// Tokens
        /// </summary>
        public string Tokens { get; set; }

        /// <summary>
        /// FIAT balance
        /// </summary>
        public string FiatBalance { get; set; }

        /// <summary>
        /// FIAT currency
        /// </summary>
        public string FiatCurrency { get; set; }

        /// <summary>
        /// Status <see cref="CustomerBalanceStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerBalanceStatus Status { get; set; }
    }
}
