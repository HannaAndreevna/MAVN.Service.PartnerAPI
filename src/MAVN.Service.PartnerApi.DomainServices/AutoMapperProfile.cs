using System.Globalization;
using AutoMapper;
using JetBrains.Annotations;
using Lykke.Service.PartnerManagement.Client.Models.Authentication;
using Lykke.Service.PartnersIntegration.Client.Models;
using MAVN.Service.PartnerApi.Domain;
using MAVN.Service.PartnerApi.Domain.Models.Customers;
using MAVN.Service.PartnerApi.Domain.Models.Message;
using MAVN.Service.PartnerApi.Domain.Models.Payment;
using MAVN.Service.PartnerApi.Domain.Models.Referral;
using BonusCustomerModel = MAVN.Service.PartnerApi.Domain.Models.Bonus.BonusCustomerModel;
using BonusCustomerResponseModel = MAVN.Service.PartnerApi.Domain.Models.Bonus.BonusCustomerResponseModel;
using BonusCustomersRequestModel = MAVN.Service.PartnerApi.Domain.Models.Bonus.BonusCustomersRequestModel;
using CustomerBalanceRequestModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerBalanceRequestModel;
using CustomerBalanceResponseModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerBalanceResponseModel;
using CustomerInformationResponseModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerInformationResponseModel;
using ReferralInformationRequestModel = MAVN.Service.PartnerApi.Domain.Models.Referral.ReferralInformationRequestModel;
using ReferralInformationResponseModel = MAVN.Service.PartnerApi.Domain.Models.Referral.ReferralInformationResponseModel;

namespace MAVN.Service.PartnerApi.DomainServices
{
    [UsedImplicitly]
    public class AutoMapperProfile : Profile
    {
        private readonly int _moneyDecimalPointStringPrecision;
        private readonly string _integerPartFormat = "R";
        private readonly string _decimalFormat = "0.##";

        public AutoMapperProfile(int moneyDecimalPointStringPrecision)
        {
            _moneyDecimalPointStringPrecision = moneyDecimalPointStringPrecision;

            CreateMap<Lykke.Service.PartnersIntegration.Client.Models.CustomerInformationResponseModel,
                    CustomerInformationResponseModel>(MemberList.Destination)
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CustomerBalanceRequestModel, Lykke.Service.PartnersIntegration.Client.Models.CustomerBalanceRequestModel>(
                    MemberList.Destination)
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.GetPartnerId()))
                .ForMember(dest => dest.ExternalLocationId, opt => opt.MapFrom(src => src.LocationId));

            CreateMap<Lykke.Service.PartnersIntegration.Client.Models.CustomerBalanceResponseModel, CustomerBalanceResponseModel>(
                    MemberList.Destination)
                .ForMember(dest => dest.Tokens,
                    opt => opt.MapFrom(src =>
                        src.Tokens.ToString(_integerPartFormat, _moneyDecimalPointStringPrecision, null)))
                .ForMember(dest => dest.FiatBalance,
                    opt => opt.MapFrom(src => src.FiatBalance.ToString(_decimalFormat, CultureInfo.InvariantCulture)));

            CreateMap<BonusCustomerModel, Lykke.Service.PartnersIntegration.Client.Models.BonusCustomerModel>(MemberList.Destination)
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.GetPartnerId()))
                .ForMember(dest => dest.ExternalLocationId, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.FiatAmount,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.FiatAmount) ? decimal.Parse(src.FiatAmount) : (decimal?) null));

            CreateMap<BonusCustomersRequestModel, Lykke.Service.PartnersIntegration.Client.Models.BonusCustomersRequestModel>(
                MemberList.Destination);

            CreateMap<Lykke.Service.PartnersIntegration.Client.Models.BonusCustomerResponseModel, BonusCustomerResponseModel>(
                    MemberList.Destination)
                .ForMember(dest => dest.CustomerStatus, opt => opt.MapFrom(src => src.Status));

            CreateMap<ReferralInformationRequestModel, Lykke.Service.PartnersIntegration.Client.Models.ReferralInformationRequestModel>(
                    MemberList.Destination)
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.GetPartnerId()))
                .ForMember(dest => dest.ExternalLocationId, opt => opt.MapFrom(src => src.LocationId));

            CreateMap<Lykke.Service.PartnersIntegration.Client.Models.ReferralInformationResponseModel,
                ReferralInformationResponseModel>(MemberList.Destination);

            CreateMap<ReferralModel, ReferralInfo>(MemberList.Destination)
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.ReferralStatus));

            CreateMap<PaymentsCreateResponseModel, CreatePaymentRequestResponseModel>(MemberList.Destination);

            CreateMap<PaymentRequestStatusResponseModel, GetPaymentRequestStatusResponseModel>(MemberList.Destination)
                .ForMember(dest => dest.TokensAmount,
                    opt => opt.MapFrom(src =>
                        src.TokensAmount.ToString(_integerPartFormat, _moneyDecimalPointStringPrecision, null)))
                .ForMember(dest => dest.TotalFiatAmount,
                    opt => opt.MapFrom(
                        src => src.TotalFiatAmount.ToString(_decimalFormat, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.FiatAmount,
                    opt => opt.MapFrom(src => src.FiatAmount.ToString(_decimalFormat, CultureInfo.InvariantCulture)));

            CreateMap<ExecutePaymentRequestRequestModel, PaymentsExecuteRequestModel>(MemberList.Destination);

            CreateMap<PaymentsExecuteResponseModel, ExecutePaymentRequestResponseModel>(MemberList.Destination)
                .ForMember(dest => dest.TokensAmount,
                    opt => opt.MapFrom(src =>
                        src.TokensAmount.ToString(_integerPartFormat, _moneyDecimalPointStringPrecision, null)))
                .ForMember(dest => dest.FiatAmount,
                    opt => opt.MapFrom(src => src.FiatAmount.ToString(_decimalFormat, CultureInfo.InvariantCulture)));

            CreateMap<PaymentsCreateRequestModel, CreatePaymentRequestRequestModel>(MemberList.Destination)
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.ExternalLocationId))
                .ForMember(dest => dest.TotalFiatAmount,
                    opt => opt.MapFrom(src =>
                        src.TotalFiatAmount.HasValue
                            ? src.TotalFiatAmount.Value.ToString(_decimalFormat, CultureInfo.InvariantCulture)
                            : string.Empty))
                .ForMember(dest => dest.FiatAmount,
                    opt => opt.MapFrom(src =>
                        src.FiatAmount.HasValue
                            ? src.FiatAmount.Value.ToString(_decimalFormat, CultureInfo.InvariantCulture)
                            : string.Empty));

            CreateMap<AuthenticateResponseModel, AuthResultModel>(MemberList.Destination);

            CreateMap<CreatePaymentRequestRequestModel, PaymentsCreateRequestModel>(MemberList.Destination)
                .ForMember(dest => dest.ExternalLocationId, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.TotalFiatAmount,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.TotalFiatAmount)
                            ? decimal.Parse(src.TotalFiatAmount)
                            : (decimal?) null))
                .ForMember(dest => dest.FiatAmount,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.FiatAmount)
                            ? decimal.Parse(src.FiatAmount)
                            : (decimal?)null));

            CreateMap<MessagesPostResponseModel, SendMessageResponseModel>(MemberList.Destination)
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.ErrorCode));

            CreateMap<SendMessageRequestModel, MessagesPostRequestModel>(MemberList.Destination)
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.GetPartnerId()))
                .ForMember(dest => dest.SendPushNotification, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.ExternalLocationId, opt => opt.MapFrom(src => src.LocationId));

            CreateMap<QueryCustomerInformationRequestModel, CustomerInformationRequestModel>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));
        }
    }
}
