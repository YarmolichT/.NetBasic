using System.Text;

namespace SerializationBinary
{
    [Serializable]
    public class Department
    {

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
