namespace ConsoleAppReflection
{
    public enum ProviderType
    {
        ConfigurationProvider = 0,
        FileConfigurationProvider = 1
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string settingName, ProviderType providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }
        public string SettingName { get; set; }
        public ProviderType ProviderType { get; set; }
    }
}
