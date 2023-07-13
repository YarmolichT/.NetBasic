using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            var empl = new Employee { EmployeeName = "Yarmolich Tatsiana" };
            var empl1 = new Employee { EmployeeName = "Ivan Ivanov" };
           
            List <Employee> EmplList = new List<Employee> { empl1, empl };

            var department = new Department() ;

            department.DepartmentName = "MSTD";
            department.Employees = EmplList;

            Console.WriteLine($"Befour serialization: {department.GetListOfValues()}" );

            XmlSerializer XMLserializer = new XmlSerializer(typeof(Department));
           
            using (StreamWriter writer = new StreamWriter("department.xml")) 
            {
                XMLserializer.Serialize(writer, department);
            }
           
            using (StreamReader reader = new StreamReader("department.xml"))
            {
                 Department deserializedDepartment = (Department)XMLserializer.Deserialize(reader);
                 Console.WriteLine($"After deserialization Name: {deserializedDepartment.GetListOfValues()}");
            }
        }

        public class Employee {
           
            [XmlElement]
            public string EmployeeName;

        }

        public class Department {
            
            [XmlElement]
            public string DepartmentName;
            [XmlElement]
            public List<Employee> Employees;
           
            public string GetListOfValues()
            {
                StringBuilder sb = new();
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