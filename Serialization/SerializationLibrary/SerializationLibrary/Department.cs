using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SerializationLibrary
{
    [Serializable]
    public class Department
    {
        [JsonPropertyName("Department Name")]
        public string DepartmentName { get; set; }

        [JsonPropertyName("Employees")]
        public List<Employee> Employees { get; set; }

        public override string ToString()
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
