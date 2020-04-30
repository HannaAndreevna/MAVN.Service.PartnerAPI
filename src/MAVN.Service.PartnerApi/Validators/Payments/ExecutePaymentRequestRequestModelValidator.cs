using FluentValidation;
using MAVN.Service.PartnerApi.Domain.Models.Payment;

namespace MAVN.Service.PartnerApi.Validators.Payments
{
    public class ExecutePaymentRequestRequestModelValidator : AbstractValidator<ExecutePaymentRequestRequestModel>
    {
        public ExecutePaymentRequestRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.PaymentRequestId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Payment request id is required")
                .MaximumLength(100)
                .WithMessage("Payment request id cannot be more then 100 characters in length");
        }
    }
}
