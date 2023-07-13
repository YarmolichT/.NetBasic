using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        public static string FileName = "Department.bin";
        static void Main(string[] args)
        {
            var empl = new Employee { EmployeeName = "Yarmolich Tatsiana" };
            var empl1 = new Employee { EmployeeName = "Ivan Ivanov" };
           
            List <Employee> EmplList = new List<Employee> { empl1, empl };

            var department = new Department() ;

            department.DepartmentName = "MSTD";
            department.Employees = EmplList;

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

        [Serializable]
        public class Employee
        {
            public string EmployeeName;
        }

        [Serializable]
        public class Department {
                        
            public string DepartmentName;
            
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