using System.Reflection;
using IProvider_ClassLib;

namespace ConsoleAppReflection
{
    public static class ProviderFinder
    {
        public static Dictionary<string, IProvider> ReturnProviders(string pathString)
        {
            Dictionary<string, IProvider> providers = new();
            var directoryFiles = ReturnDirectoryFiles(pathString);

            foreach (var file in directoryFiles)
            {
                var pluginAssembly = Assembly.LoadFrom(file);
                var provider = CreateProvider(pluginAssembly);
                providers.Add(provider.GetType().Name, provider);
            }
            return providers;
        }

        private static IProvider CreateProvider(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IProvider).IsAssignableFrom(type))
                {
                    var result = Activator.CreateInstance(type) as IProvider;
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
        
        private static List<string> ReturnDirectoryFiles(string shortPath)
        {
            var root = Environment.CurrentDirectory;
            var pluginLocation = Path.GetFullPath(Path.Combine(root, shortPath.Replace('\\', Path.DirectorySeparatorChar)));
            var directoryFiles = Directory.GetFiles(pluginLocation).ToList();

            return directoryFiles;
        }
    }
}
