using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jeffrey_Smith_Challenge2_Part1
{
    // Define the Employee class with properties Name, Age, and Department
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }
    internal class Jeffrey_Smith_Challenge2_Part1
    {
        static void Main(string[] args)
        {
            // Create a list of employees
            var employees = new List<Employee>
            {
                new Employee { Name = "John", Age = 29, Department = "HR" },
                new Employee { Name = "Sara", Age = 22, Department = "IT" },
                new Employee { Name = "Alice", Age = 35, Department = "Finance" },
                new Employee { Name = "Bob", Age = 28, Department = "Marketing" },
                new Employee { Name = "Eve", Age = 40, Department = "IT" }
            };

            // Use LINQ to filter, sort, and project the data
            var result = employees
                .Where(e => e.Age >= 25)
                .OrderByDescending(e => e.Age)
                .Select(e => new { e.Name, e.Department })
                .ToList();

            // Print the results
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}, {item.Department}");
            }

        }
    }
}
