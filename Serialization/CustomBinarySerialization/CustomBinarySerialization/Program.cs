using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomBinarySerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                Name = "Tatsiana",
                Age = 18
            };

            Console.WriteLine($"Before serialization:\n{person.GetListOfValues()}");

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Binary.bin", FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, person);
            stream.Close();

            Stream streamReader = new FileStream("Binary.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Person dedeserializedDepartment = (Person)formatter.Deserialize(streamReader);

            Console.WriteLine($"After serialization:\n{dedeserializedDepartment.GetListOfValues()}");
        }
    }
}