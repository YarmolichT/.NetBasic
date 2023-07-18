using SerializationBinary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class Program
    {
        public static string FileName = "Department.bin";
        static void Main(string[] args)
        {           
            var firstEmployee = new Employee { EmployeeName = "Yarmolich Tatsiana" };
            var secondEmployee = new Employee { EmployeeName = "Ivan Ivanov" };
           
            List <Employee> employees = new List<Employee> { firstEmployee, secondEmployee };

            var department = new Department() ;

            department.DepartmentName = "MSTD";
            department.Employees = employees;

            Console.WriteLine($"Befour serialization:\n{department.GetListOfValues()}" );

            IFormatter formatter = new BinaryFormatter();
            Stream streamWriter = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(streamWriter, department);
            streamWriter.Close();

            Stream streamReader = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Department deserializedDepartment = (Department)formatter.Deserialize(streamReader);
            streamReader.Close();

            Console.WriteLine($"After serialization:\n{deserializedDepartment.GetListOfValues()}");
        }
    }
}