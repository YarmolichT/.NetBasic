using SerializationLibrary;
using System.Text.Json;

namespace Serialization
{
    public class Program
    {
        public static string FileName = "department.json";

        static void Main(string[] args)
        {
            var firstEmployee = new Employee { EmployeeName = "Yarmolich Tatsiana" };
            var secondEmployee = new Employee { EmployeeName = "Ivan Ivanov" };
           
            List <Employee> employees = new List<Employee> { firstEmployee, secondEmployee };

            var department = new Department() ;

            department.DepartmentName = "MSTD";
            department.Employees = employees;          

            Console.WriteLine($"Before serialization: {department}" );

            string json = JsonSerializer.Serialize(department);
            File.WriteAllText(FileName, json);
            Console.WriteLine(json);

            var jsonString1 = File.ReadAllText(FileName);
            Department deserializedEmployee = JsonSerializer.Deserialize<Department>(jsonString1);  

            Console.WriteLine($"After deserialization Name: {deserializedEmployee}" );           
        }       
    }
}