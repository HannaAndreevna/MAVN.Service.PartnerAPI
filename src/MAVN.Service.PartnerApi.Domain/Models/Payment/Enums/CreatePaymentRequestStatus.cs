namespace MAVN.Service.PartnerApi.Domain.Models.Payment.Enums
{
    /// <summary>
    /// Represents payment request status
    /// </summary>
    public enum CreatePaymentRequestStatus
    {
        /// <summary>
        /// Ok
        /// </summary>
        OK,

        /// <summary>
        /// Customer not found
        /// </summary>
        CustomerNotFound,

        /// <summary>
        /// Customer is blocked
        /// </summary>
        CustomerIsBlocked,

        /// <summary>
        /// Partner not found
        /// </summary>
        PartnerNotFound,

        /// <summary>
        /// Location not found
        /// </summary>
        LocationNotFound,

        /// <summary>
        /// Invalid currency
        /// </summary>
        InvalidCurrency,

        /// <summary>
        /// Cannot pass both fiat and tokens amount
        /// </summary>
        CannotPassBothFiatAndTokensAmount,
        
        /// <summary>
        /// Either Fiat or Tokens amount should be passed
        /// </summary>
        EitherFiatOrTokensAmountShouldBePassed,
        
        /// <summary>
        /// Invalid Tokens amount
        /// </summary>
        InvalidTokensAmount,
        
        /// <summary>
        /// Invalid Fiat amount
        /// </summary>
        InvalidFiatAmount,
        
        /// <summary>
        /// Invalid total bill amount
        /// </summary>
        InvalidTotalBillAmount,

        /// <summary>
        /// Internal technical error 
        /// </summary>
        InternalTechnicalError
    }
}
