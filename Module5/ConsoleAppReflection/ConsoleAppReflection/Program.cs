namespace ConsoleAppReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customManager = new CustomItemManager();

            Console.WriteLine("Using Configuration Provider");
            ConfigurationProviderAttribute configProvider = new();
            Console.WriteLine(configProvider);
            customManager.ReadFromFile(configProvider);
            Console.WriteLine(configProvider);

            configProvider.IntValue = 12345;
            configProvider.FloatValue = 9.234f;
            configProvider.StringValue = "string";
            configProvider.TimeSpanValue = TimeSpan.MinValue;
            customManager.WriteToFile(configProvider);
            customManager.ReadFromFile(configProvider);
            Console.WriteLine(configProvider);

            Console.WriteLine("Using Configuration Provider");
            FileProviderAttribute fileProvider = new();
            // return empty properties
            Console.WriteLine(fileProvider); 
            customManager.ReadFromFile(fileProvider);
            // return properties from json custom file
            Console.WriteLine(fileProvider); 

            fileProvider.IntValue = 9234599;
            fileProvider.FloatValue = 1.234f;
            fileProvider.StringValue = "string999";
            fileProvider.TimeSpanValue = TimeSpan.MinValue;
            customManager.WriteToFile(fileProvider);
            // return updated properties 
            Console.WriteLine(fileProvider); 
        }
    }
}