using System.Text.Json.Serialization;

namespace SerializationLibrary
{
    [Serializable]
    public class Employee
    {
        [JsonInclude]
        [JsonPropertyName("Employee Name")]
        public string EmployeeName { get; set; }
    }
}