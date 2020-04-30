using JetBrains.Annotations;
using MAVN.Service.PartnerApi.Settings.Service.Db;

namespace MAVN.Service.PartnerApi.Settings.Service
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class PartnerApiSettings
    {
        public DbSettings Db { get; set; }

        public CacheSettings CacheSettings { get; set; }

        public int MoneyDecimalPointStringPrecision { get; set; }
    }
}
