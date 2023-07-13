using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serialization
{
    public class Program
    {
        public static string FileName = "department.json";

        static void Main(string[] args)
        {
            var empl = new Employee { EmployeeName = "Yarmolich Tatsiana" };
            var empl1 = new Employee { EmployeeName = "Ivan Ivanov" };
           
            List <Employee> EmplList = new List<Employee> { empl1, empl };

            var department = new Department() ;

            department.DepartmentName = "MSTD";
            department.Employees = EmplList;          

            Console.WriteLine($"Before serialization: {department.GetListOfValues()}" );

            string json = JsonSerializer.Serialize(department);
            File.WriteAllText(FileName, json);
            Console.WriteLine(json);

            var jsonString1 = File.ReadAllText(FileName);
            Department deserializedEmployee = JsonSerializer.Deserialize<Department>(jsonString1);  

            Console.WriteLine($"After deserialization Name: {deserializedEmployee.GetListOfValues()}" );           
        }

        public class Employee {
            
            [JsonInclude]
            [JsonPropertyName("Employee Name")]
            public string EmployeeName;

        }

        public class Department {
           
            [JsonPropertyName("Department Name")]
            public string DepartmentName { get; set; }
          
            [JsonPropertyName("Employees")]
            public List<Employee> Employees { get; set; }

            public string GetListOfValues()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Department name: {DepartmentName}");

                foreach (var employee in Employees)
                {
                    sb.AppendLine($"Employee name: {employee.EmployeeName}");
                }

                return sb.ToString();
            }
        }
    }
}