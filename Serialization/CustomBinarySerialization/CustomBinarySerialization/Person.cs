using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomBinarySerialization
{
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(SerializationInfo info , StreamingContext context) {

            Name = info.GetString("UserName");
            Age = info.GetInt16("18");     
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("UserName", Name);
            info.AddValue("18", Age);
        }

        public string GetListOfValues()
        {
            StringBuilder sb = new();
            sb.AppendLine("Person:");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Age: {Age}");

            return sb.ToString();
        }
    }
}
