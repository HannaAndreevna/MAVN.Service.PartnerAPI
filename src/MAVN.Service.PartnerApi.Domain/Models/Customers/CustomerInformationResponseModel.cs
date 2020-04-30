using MAVN.Service.PartnerApi.Domain.Models.Customers.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Customers
{
    /// <summary>
    /// Customer information response model
    /// </summary>
    public class CustomerInformationResponseModel
    {
        /// <summary>
        /// Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Status <see cref="CustomerBalanceStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerBalanceStatus Status { get; set; }

        /// <summary>
        /// Tier level
        /// </summary>
        public string TierLevel { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
    }
}
