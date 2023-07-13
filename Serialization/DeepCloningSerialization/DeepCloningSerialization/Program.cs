namespace DeepCloningSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee { EmployeeName = "Tatsiana" };
            var employee1 = new Employee { EmployeeName = "EmplName" };
            var department = new Department
            {
                DepartmentName = "MSTD",
                EmployeeList = new List<Employee> { employee, employee1 }
            };

            Console.WriteLine("Values from Department:");
            Console.WriteLine(department);

            var department1 = department.Clone(); 
            Console.WriteLine("Values from Departmen1(clone):");
            Console.WriteLine(department1 );          

            department.DepartmentName = "New department";
            department.EmployeeList[0].EmployeeName = "Ivan";
            department.EmployeeList[1].EmployeeName = "Kate";
           
            Console.WriteLine("Values from Departmen were changed:");
            Console.WriteLine(department);

            Console.WriteLine("Deep copy of Department1 has no changes:");
            Console.WriteLine(department1);
        }
    }
}