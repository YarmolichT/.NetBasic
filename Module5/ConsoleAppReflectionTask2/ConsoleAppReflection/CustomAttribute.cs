namespace ConsoleAppReflection
{
    public enum ProviderType
    {
        ConfigurationProvider = 0,
        FileConfigurationProvider = 1
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ConfigurationItemAttribute : Attribute
    {
        public ConfigurationItemAttribute(string settingName, string providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }

        public string SettingName { get; set; }

        public string ProviderType { get; set; }
    }

}
