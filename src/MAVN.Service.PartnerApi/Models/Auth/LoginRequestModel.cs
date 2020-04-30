using JetBrains.Annotations;

namespace MAVN.Service.PartnerApi.Models.Auth
{
    /// <summary>
    /// Represents login request
    /// </summary>
    [PublicAPI]
    public class LoginRequestModel
    {
        /// <summary>
        /// Client id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret (password)
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Additional information related to user
        /// </summary>
        public string UserInfo { get; set; }
    }
}
