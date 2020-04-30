using JetBrains.Annotations;

namespace MAVN.Service.PartnerApi.Models.Auth
{
    /// <summary>
    /// Represents login response
    /// </summary>
    [PublicAPI]
    public class LoginResponseModel
    {
        /// <summary>
        /// Authentication token
        /// </summary>
        public string Token { get; set; }
    }
}
