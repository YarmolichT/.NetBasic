using SerializationLibrary;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            var firstEmployee = new Employee { EmployeeName = "Yarmolich Tatsiana" };
            var secondEmployee = new Employee { EmployeeName = "Ivan Ivanov" };
           
            List <Employee> employees = new List<Employee> { firstEmployee, secondEmployee };

            var department = new Department() ;

            department.DepartmentName = "MSTD";
            department.Employees = employees;

            Console.WriteLine($"Before serialization: {department}" );

            XmlSerializer XmlSerializer = new XmlSerializer(typeof(Department));
           
            using (StreamWriter writer = new StreamWriter("department.xml")) 
            {
                XmlSerializer.Serialize(writer, department);
            }
           
            using (StreamReader reader = new StreamReader("department.xml"))
            {
                 Department deserializedDepartment = (Department)XmlSerializer.Deserialize(reader);
                 Console.WriteLine($"After deserialization Name: {deserializedDepartment}");
            }
        }
    }
}