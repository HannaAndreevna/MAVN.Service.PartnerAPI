using MAVN.Service.PartnerApi.Domain.Models.Message.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAVN.Service.PartnerApi.Domain.Models.Message
{
    /// <summary>
    /// Represents send message response model
    /// </summary>
    public class SendMessageResponseModel
    {
        /// <summary>
        /// Partner message id
        /// </summary>
        public string PartnerMessageId { get; set; }

        /// <summary>
        /// Status <see cref="SendMessageStatus"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SendMessageStatus Status { get; set; }
    }
}
