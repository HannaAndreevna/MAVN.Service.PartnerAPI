using FluentValidation;
using MAVN.Service.PartnerApi.Domain.Models.Payment;

namespace MAVN.Service.PartnerApi.Validators.Payments
{
    public class CreatePaymentRequestRequestModelValidator : AbstractValidator<CreatePaymentRequestRequestModel>
    {
        public CreatePaymentRequestRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Customer id is required")
                .MaximumLength(100)
                .WithMessage("Customer id cannot be more then 100 characters in length");

            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.FiatAmount) || x.TokensAmount.HasValue)
                .WithMessage("Fiat or token amount is required");

            RuleFor(x => x.TotalFiatAmount)
                .NotNull()
                .NotEmpty()
                .WithMessage("Total Fiat amount is required");

            RuleFor(x => x.LocationId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Location id is required");

            When(x => !string.IsNullOrEmpty(x.TotalFiatAmount), () =>
            {
                decimal convertedValue = 0;

                RuleFor(x => x.TotalFiatAmount)
                    .Must(y => decimal.TryParse(y, out convertedValue))
                    .WithMessage("Total Fiat amount must be decimal number")
                    .Must(x => convertedValue > 0)
                    .WithMessage("Total Fiat amount is must be greater then 0");
            });

            When(x => !string.IsNullOrEmpty(x.FiatAmount), () =>
            {
                decimal convertedValue = 0;

                RuleFor(x => x.FiatAmount)
                    .Must(y => decimal.TryParse(y, out convertedValue))
                    .WithMessage("Fiat amount must be decimal number")
                    .Must(x => convertedValue > 0)
                    .WithMessage("Fiat amount is must be greater then 0");
            });

            RuleFor(x => x.Currency)
                .NotNull()
                .NotEmpty()
                .WithMessage("Currency is required");

            When(x => !string.IsNullOrEmpty(x.Currency), () =>
            {
                RuleFor(x => x.Currency)
                    .MaximumLength(20)
                    .WithMessage("Currency cannot be more then 20 characters in length");
            });

            When(x => x.TokensAmount.HasValue, () =>
            {
                RuleFor(x => x.TokensAmount)
                    .GreaterThan(0)
                    .WithMessage("Tokens amount must be greater then 0");
            });

            When(x => !string.IsNullOrEmpty(x.PaymentInfo), () =>
            {
                RuleFor(x => x.PaymentInfo)
                    .MaximumLength(5120)
                    .WithMessage("Payment info cannot be more then 5120 characters in length");
            });

            When(x => !string.IsNullOrEmpty(x.LocationId), () =>
            {
                RuleFor(x => x.LocationId)
                    .MaximumLength(100)
                    .WithMessage("Location id cannot be more then 100 characters in length");
            });

            When(x => !string.IsNullOrEmpty(x.PosId), () =>
            {
                RuleFor(x => x.PosId)
                    .MaximumLength(100)
                    .WithMessage("Pos id cannot be more then 100 characters in length");
            });

            When(x => !string.IsNullOrEmpty(x.PaymentProcessedCallbackUrl), () =>
            {
                RuleFor(x => x.PaymentProcessedCallbackUrl)
                    .MaximumLength(512)
                    .WithMessage("Payment processed callback url cannot be more then 512 characters in length");
            });

            When(x => x.ExpirationTimeoutInSeconds.HasValue, () =>
            {
                RuleFor(x => x.ExpirationTimeoutInSeconds)
                    .GreaterThan(0)
                    .LessThanOrEqualTo(int.MaxValue)
                    .WithMessage("Expiration timeout in seconds must be positive integer number");
            });
        }
    }
}
