using FluentValidation;
using MAVN.Service.PartnerApi.Domain.Models.Message;

namespace MAVN.Service.PartnerApi.Validators.Messages
{
    public class SendMessageRequestModelValidator : AbstractValidator<SendMessageRequestModel>
    {
        public SendMessageRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Customer id is required")
                .Length(1, 100)
                .WithMessage("Customer id must be between 1 and 100 characters in length");

            RuleFor(x => x.Subject)
                .NotNull()
                .NotEmpty()
                .WithMessage("Subject is required")
                .Length(1, 100)
                .WithMessage("Subject must be between 1 and 100 characters in length");

            RuleFor(x => x.Message)
                .NotNull()
                .NotEmpty()
                .WithMessage("Message is required")
                .Length(1, 5120) //5120 = 10240B = 10KB
                .WithMessage("Message must be between 1 and 5120 characters in length");

            RuleFor(x => x.LocationId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Location id is required");

            When(x => !string.IsNullOrEmpty(x.LocationId), () =>
            {
                RuleFor(y => y.LocationId)
                    .Length(1, 100)
                    .WithMessage("Location id must be between 1 and 100 characters in length");
            });

            When(x => !string.IsNullOrEmpty(x.PosId), () =>
            {
                RuleFor(y => y.PosId)
                    .Length(1, 100)
                    .WithMessage("Pos id must be between 1 and 100 characters in length");
            });
        }
    }
}
