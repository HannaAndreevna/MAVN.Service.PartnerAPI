namespace MAVN.Service.PartnerApi.Domain.Models.Bonus.Enums
{
    public enum BonusCustomerStatus
    {
        OK,
        CustomerNotFound,
        PartnerNotFound,
        CustomerIdDoesNotMatchEmail,
        InvalidCurrency,
        InvalidFiatAmount,
        InvalidPaymentTimestamp,
        TechnicalProblem
    }
}
