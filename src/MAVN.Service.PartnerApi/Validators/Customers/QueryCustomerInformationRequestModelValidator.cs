using FluentValidation;
using JetBrains.Annotations;
using MAVN.Service.PartnerApi.Domain.Models.Customers;

namespace MAVN.Service.PartnerApi.Validators.Customers
{
    [UsedImplicitly]
    public class QueryCustomerInformationRequestModelValidator : AbstractValidator<QueryCustomerInformationRequestModel>
    {
        public QueryCustomerInformationRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.CustomerId) || !string.IsNullOrEmpty(x.Email) ||
                           !string.IsNullOrEmpty(x.Phone))
                .WithMessage("At least one of three (customer id, email, phone) parameters must have value");
        }
    }
}
