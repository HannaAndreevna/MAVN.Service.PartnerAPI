using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.PartnerApi.Settings.Service.Db
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
    }
}
