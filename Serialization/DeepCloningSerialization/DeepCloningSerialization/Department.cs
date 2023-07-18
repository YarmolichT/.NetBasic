using SerializationLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DeepCloningSerialization
{
    [Serializable]
    public class Department : ICloneable
    {
        public string DepartmentName;
        public List<Employee> EmployeeList;

        public Object Clone() {

            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }

                return null;
            }   
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Department name: {DepartmentName}");
            foreach (var employee in EmployeeList)
            {
                sb.AppendLine($"Employee name: {employee.EmployeeName}");
            }

            return sb.ToString();
        }
    }
}
