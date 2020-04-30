using AutoFixture;
using AutoMapper;
using Lykke.Service.PartnersIntegration.Client.Models;
using Xunit;
using BonusCustomerResponseModel = MAVN.Service.PartnerApi.Domain.Models.Bonus.BonusCustomerResponseModel;
using CustomerBalanceResponseModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerBalanceResponseModel;
using CustomerInformationResponseModel = MAVN.Service.PartnerApi.Domain.Models.Customers.CustomerInformationResponseModel;
using ReferralInformationResponseModel = MAVN.Service.PartnerApi.Domain.Models.Referral.ReferralInformationResponseModel;

namespace MAVN.Service.PartnerApi.Tests
{
    public class AutoMapperProfileTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly IMapper _mapper;

        public AutoMapperProfileTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PartnerApi.DomainServices.AutoMapperProfile(3));
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void Mapping_Configuration_Is_Correct()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();

            Assert.True(true);
        }

        [Fact]
        public void
            When_Customer_Information_Response_Model_Is_Mapped_To_Customer_Response_Model_Then_Properties_Are_Mapped_Properly()
        {
            var src = _fixture.Create<Lykke.Service.PartnersIntegration.Client.Models.CustomerInformationResponseModel>();
            var dest = _mapper.Map<CustomerInformationResponseModel>(src);

            Assert.Equal(src.Id, dest.CustomerId);
            Assert.Equal(src.TierLevel, dest.TierLevel);
            Assert.Equal(src.Status.ToString(), dest.Status.ToString());
            Assert.Equal((int)src.Status, (int)dest.Status);
        }

        [Fact]
        public void
            When_Partners_Integration_Client_Models_Customer_Balance_Response_Model_Is_Mapped_To_Customer_Balance_Response_Model_Then_Properties_Are_Mapped_Properly()
        {
            var src = _fixture.Create<Lykke.Service.PartnersIntegration.Client.Models.CustomerBalanceResponseModel>();
            var dest = _mapper.Map<CustomerBalanceResponseModel>(src);

            Assert.Equal(src.Tokens.ToString("R", 3), dest.Tokens);
            Assert.Equal(src.Status.ToString(), dest.Status.ToString());
            Assert.Equal((int)src.Status, (int)dest.Status);
        }

        [Fact]
        public void
            When_Bonus_Customer_Trigger_Response_Model_Is_Mapped_To_Trigger_Bonus_To_Customer_Response_Model_Then_Properties_Are_Mapped_Properly()
        {
            var src = _fixture.Create<Lykke.Service.PartnersIntegration.Client.Models.BonusCustomerResponseModel>();
            var dest = _mapper.Map<BonusCustomerResponseModel>(src);

            Assert.Equal(src.Status.ToString(), dest.CustomerStatus.ToString());
            Assert.Equal((int)src.Status, (int)dest.CustomerStatus);
        }

        [Fact]
        public void
            When_Referral_Information_Response_Model_Is_Mapped_To_Trigger_Bonus_To_Referral_Response_Model_Then_Properties_Are_Mapped_Properly()
        {
            var src = _fixture.Create<Lykke.Service.PartnersIntegration.Client.Models.ReferralInformationResponseModel>();
            var dest = _mapper.Map<ReferralInformationResponseModel>(src);

            Assert.Equal(src.Status.ToString().ToLower(), dest.Status.ToString().ToLower());
            Assert.Equal((int)src.Status, (int)dest.Status);
        }

        [Fact]
        public void When_Referral_Model_Is_Mapped_To_Referral_Info_Then_Properties_Are_Mapped_Properly()
        {
            var src = _fixture.Create<ReferralModel>();
            var dest = _mapper.Map<Domain.Models.Referral.ReferralInfo>(src);

            Assert.Equal(src.ReferralStatus.ToString().ToLower(), dest.Status.ToString().ToLower());
            Assert.Equal((int)src.ReferralStatus, (int)dest.Status);
        }
    }
}
