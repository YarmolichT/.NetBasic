using System.Text;
using System.Text.Json;

namespace ConsoleAppReflection
{
    public class FileConfigurationProvider : IProvider
    {
        private readonly Dictionary<string, string> _appJsonFile;
        private string JsonFilePath =  "customFile.json";

        public FileConfigurationProvider()
        {
            _appJsonFile = GetAppFile();
        }

        private Dictionary<string, string> GetAppFile()
        {
            var jsonFile = File.ReadAllText(JsonFilePath);
            var jsonData = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonFile);

            return jsonData;
        }

        public string GetValue(string key)
        {
            return _appJsonFile[key];
        }

        public void SetValue(string key, string value)
        {
            _appJsonFile[key] = value;
        }

        public void SaveChanges()
        {
            var jsonObject = JsonSerializer.Serialize(_appJsonFile);
            File.WriteAllText(JsonFilePath, jsonObject);
        }
    }

    public class FileProviderAttribute
    {

        [CustomAttribute(nameof(StringValue), ProviderType.FileConfigurationProvider)]
        public string StringValue { get; set; }

        [CustomAttribute(nameof(IntValue), ProviderType.FileConfigurationProvider)]
        public int IntValue { get; set; }

        [CustomAttribute(nameof(FloatValue), ProviderType.FileConfigurationProvider)]
        public float FloatValue { get; set; }

        [CustomAttribute(nameof(TimeSpanValue), ProviderType.FileConfigurationProvider)]
        public TimeSpan TimeSpanValue { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("FileProviderItem:");
            sb.AppendLine($"StringValue: {StringValue}");
            sb.AppendLine($"IntValue: {IntValue}");
            sb.AppendLine($"FloatValue: {FloatValue}");
            sb.AppendLine($"TimeSpanValue: {TimeSpanValue}");

            return sb.ToString();
        }
    }
}
