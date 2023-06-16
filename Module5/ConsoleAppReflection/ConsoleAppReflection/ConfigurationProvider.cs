using System.Configuration;
using System.Text;

namespace ConsoleAppReflection
{
    public class ConfigurationProvider : IProvider
    {
        private readonly Dictionary<string, string> _configurationProvider;

        public ConfigurationProvider()
        {
            _configurationProvider = GetAppSettings();
        }
        private Dictionary<string, string> GetAppSettings()
        {
            Dictionary<string, string> appSettingsData = new();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key != null)
                {
                    var value = ConfigurationManager.AppSettings[key];

                    if (value != null)
                    {
                        appSettingsData.Add(key, value);
                    }
                }
            }
            return appSettingsData;
        }

        public string GetValue(string key)
        {
            return _configurationProvider[key];
        }

        public void SetValue(string key, string value)
        {
            _configurationProvider[key] = value;
        }

        public void SaveChanges()
        {
            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

            foreach (var pair in _configurationProvider)
            {
                if (settings[pair.Key] == null)
                {
                    settings.Add(pair.Key, pair.Value);
                }
                else
                {
                    settings.Remove(pair.Key);
                    settings.Add(pair.Key, pair.Value);
                }
            }
            configFile.Save(ConfigurationSaveMode.Modified);
        }
    }

    public class ConfigurationProviderAttribute
    {

        [CustomAttribute(nameof(StringValue), ProviderType.ConfigurationProvider)]
        public string StringValue { get; set; }

        [CustomAttribute(nameof(IntValue), ProviderType.ConfigurationProvider)]
        public int IntValue { get; set; }

        [CustomAttribute(nameof(FloatValue), ProviderType.ConfigurationProvider)]
        public float FloatValue { get; set; }

        [CustomAttribute(nameof(TimeSpanValue), ProviderType.ConfigurationProvider)]
        public TimeSpan TimeSpanValue { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("ConfigurationProvider:");
            sb.AppendLine($"StringValue: {StringValue}");
            sb.AppendLine($"IntValue: {IntValue}");
            sb.AppendLine($"FloatValue: {FloatValue}");
            sb.AppendLine($"TimeSpanValue: {TimeSpanValue}");

            return sb.ToString();
        }
    }
}
