using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge3_Q2
{
    // Student class with nullable properties
    public class Student
    {
        public string Name { get; set; }
        public string Major { get; set; }
        public double? GPA { get; set; }           // Nullable GPA
        public int? GraduationYear { get; set; }   // Nullable Graduation Year

        public Student(string name, string major, double? gpa = null, int? gradYear = null)
        {
            Name = name;
            Major = major;
            GPA = gpa;
            GraduationYear = gradYear;
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Name: {Name}, Major: {Major}");
            Console.WriteLine(GPA.HasValue ? $"GPA: {GPA}" : "GPA: N/A");
            Console.WriteLine(GraduationYear.HasValue ? $"Graduation Year: {GraduationYear}" : "Graduation Year: N/A");
        }
    }

    // Generic registry for students
    public class StudentRegistry<T> where T : Student
    {
        private List<T> students; // complete this part: initialize this list in the constructor

        public StudentRegistry()
        {
            // initialize the students list
            students = new List<T>();
        }

        public void AddStudent(T student)
        {
            // Add the student to the collection
            students.Add(student);

        }

        public IEnumerable<T> GetStudentsWithGPA()
        {
            // return students where GPA.HasValue is true
            if (students == null)
                throw new ArgumentNullException("students");
            return students.Where(s => s.GPA.HasValue);
        }

        public IEnumerable<T> GetStudentsWithGraduationYear()
        {
            // TODO: return students where GraduationYear.HasValue is true
            if (students == null)
                throw new ArgumentNullException("students");
            return students.Where(s => s.GraduationYear.HasValue);
        }

        public void DisplayAll()
        {
            // TODO: iterate students and call DisplayStudentInfo or print "No students." when empty
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students.");
                return;
            }
            foreach (var student in students)
            {
                student.DisplayStudentInfo();
                Console.WriteLine(); // for better readability
            }
        }
    }
        // Main program to test the registry
        class Jeffrey_Smith_Challenge3_Q2
        {
            static void Main(string[] args)
            {
                // TODO: Create several Student objects (some with GPA, some without), add to StudentRegistry<Student>
                // Example:
                // var s1 = new Student(\"Alice\", \"CS\", 3.8, 2024);
                // var s2 = new Student(\"Bob\", \"Math\");
                // var registry = new StudentRegistry<Student>();
                // registry.AddStudent(s1);
                // registry.AddStudent(s2);
                // registry.DisplayAll();
                var s1 = new Student("Alice", "CS", 3.8, 2026);
                var s2 = new Student("Bob", "Math");
                var s3 = new Student("Mark", "ECE", 3.5, 2027);
                var s4 = new Student("Mary", "PES", 2.7);
                var registry = new StudentRegistry<Student>();
                registry.AddStudent(s1);
                registry.AddStudent(s2);
                registry.AddStudent(s3);
                registry.AddStudent(s4);
                registry.DisplayAll();

                Console.WriteLine();
                Console.WriteLine("Students with GPA:");
                var withGpa = registry.GetStudentsWithGPA();
                foreach (var s in withGpa) s.DisplayStudentInfo();
            }
        }
    
}
