using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge2_Part4
{
    // Define a Student class with properties for Name, Subject, and Grade
    public class Student
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public int Grade { get; set; }
    }

    internal class Jeffrey_Smith_Challenge2_Part4
    {
        static void Main(string[] args)
        {
            // Create a list of students with their respective subjects and grades
            var students = new List<Student>
            {
                new Student { Name = "Mike", Subject = "Math", Grade = 85 },
                new Student { Name = "Emma", Subject = "English", Grade = 90 },
                new Student { Name = "Liam", Subject = "Math", Grade = 78 },
                new Student { Name = "Sophia", Subject = "Science", Grade = 88 }
            };

            // Use LINQ to filter students with grades 80 and above, and select their names and subjects
            var result = students
                .Where(s => s.Grade >= 80)
                .Select(s => new { s.Name, s.Subject })
                .ToList();

            // Print the results
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name}, Subject: {item.Subject}");
            }

        }
    }
}
