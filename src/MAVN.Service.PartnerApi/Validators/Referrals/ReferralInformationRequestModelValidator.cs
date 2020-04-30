using FluentValidation;
using MAVN.Service.PartnerApi.Domain.Models.Referral;

namespace MAVN.Service.PartnerApi.Validators.Referrals
{
    public class ReferralInformationRequestModelValidator : AbstractValidator<ReferralInformationRequestModel>
    {
        public ReferralInformationRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty()
                .WithMessage("CustomerId is required")
                .MaximumLength(100)
                .WithMessage("CustomerId cannot be more then 100 characters in length");
        }
    }
}
