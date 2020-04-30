using FluentValidation;
using JetBrains.Annotations;
using MAVN.Service.PartnerApi.Domain.Models.Customers;

namespace MAVN.Service.PartnerApi.Validators.Customers
{
    [UsedImplicitly]
    public class CustomerBalanceRequestModelValidator : AbstractValidator<CustomerBalanceRequestModel>
    {
        public CustomerBalanceRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Currency)
                .NotNull()
                .NotEmpty()
                .WithMessage("Currency is required")
                .Length(1, 20)
                .WithMessage("Currency must be between 1 and 20 characters in length");

            RuleFor(x => x.LocationId)
                .MaximumLength(100)
                .WithMessage("Location id cannot be more then 100 characters in length");
        }
    }
}
