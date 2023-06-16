using System.IO;
using System.Reflection;

namespace ConsoleAppReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            var path1 =  Path.GetFullPath(Directory.GetCurrentDirectory() + "\\..\\..\\\\..\\..\\..\\Plagins");
            var customManager = new CustomItemManager(path1);

            CustomItem item = new();
            
            item.SecondItemProp = 2345;
            item.FifthItemProp = "string";
            item.SixthItemProp = 2222;
            customManager.WriteToFile(item);
            customManager.ReadFromFile(item);
            Console.WriteLine(item);
            CustomItem item2 = new();
            Console.WriteLine(item2);
            customManager.ReadFromFile(item);
            Console.WriteLine(item);
        }
    }
}