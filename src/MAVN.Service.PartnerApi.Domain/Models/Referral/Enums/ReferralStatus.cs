namespace MAVN.Service.PartnerApi.Domain.Models.Referral.Enums
{
    /// <summary>
    /// Referral status
    /// </summary>
    public enum ReferralStatus
    {
        /// <summary>
        /// OK
        /// </summary>
        OK,

        /// <summary>
        /// Referral expired
        /// </summary>
        ReferralExpired,

        /// <summary>
        /// Referral not confirmed
        /// </summary>
        ReferralNotConfirmed,

        /// <summary>
        /// Referral already used
        /// </summary>
        ReferralAlreadyUsed
    }
}
