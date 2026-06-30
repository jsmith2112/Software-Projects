using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssignment1
{
    internal class Program
    {
        public abstract class Person
        {
            // Crate a public property called FirstName of type string
            public string FirstName { get; set; }
            // Crate a public property called LastName of type string and Age type int
            public string LastName { get; set; }
            public int Age { get; set; }
            // Create a public string method called GetFullName that returns the full name of the person
            public string GetFullName()
            {
                return FirstName + " " + LastName;
            }
        }
        public interface IEnrollable
        {
            // Define a void abstract method that receives an object called course of type Course
            void EnrollInCourse(Course course);
        }
        public class  Student:Person, IEnrollable
        {
            // Create a prperty called EnrolledCourses of type List<Course> and say it is equal to a new List<Course>
            public List<Course> EnrolledCourses { get; set; } = new List<Course>();
            // Create a public void method called ErollInCourse that receives an object called course of type Course
            public void EnrollInCourse(Course course)
            {
                // use add method to add the course to the EnrolledCourses list
                EnrolledCourses.Add(course);
            }
        }
        public class Course
        {
            // Create two public properties called CoursenName of type string and Credits of type int
            public string CourseName { get; set; }
            public int Credits { get; set; }
        }
        public class  CourseManagementSystem
        {
            // Create two private properties one type List<Course> named courses and one type List<Student> called students use ne keyword
            private List<Course> courses = new List<Course>();
            private List<Student> students = new List<Student>();

            // Create a public void method called AddCourse that receives a course object of type Course
            public void AddCourse(Course course)
                {
                // use add method to add the course to the courses list
                courses.Add(course);
            }
            // Create a public void method called AddStudent that receives a student object of type Student
            public void AddStudent(Student student)
            {
                // use add method to add the student to the students list
                students.Add(student);
            }
            // Create a public method called GetStudentsEnrolledInCourse with IEnumerable<Student> return type that receives an object called courseName of type string
            public IEnumerable<Student> GetStudentsEnrolledInCourse(string courseName)
                {
                // return a list of students that are enrolled in a course with a specific courseName
                return students.Where(s => s.EnrolledCourses.Any(c => c.CourseName == courseName));
            }
            // Create public method called GetAverageCreditsEnrolledByStudents with double return type. Recieves no object.
            public double GetAverageCreditsEnrolledByStudents()
            {
                // return the average number of credits enrolled by students
                return students.Average(s => s.EnrolledCourses.Sum(c => c.Credits));
            }
        }

        static void Main(string[] args)
        {
            // Create courses
            Course math101 = new Course { CourseName = "Math 101", Credits = 3 };
            Course cs101 = new Course { CourseName = "CS 101", Credits = 4 };
            Course history101 = new Course { CourseName = "History 101", Credits = 3 };

            // Create students
            Student student1 = new Student { FirstName = "John", LastName = "Doe", Age = 20 };
            Student student2 = new Student { FirstName = "Jane", LastName = "Smith", Age = 22 };
            Student student3 = new Student { FirstName = "Alice", LastName = "Brown", Age = 21 };

            // Enroll students in courses
            student1.EnrollInCourse(math101);
            student1.EnrollInCourse(cs101);

            student2.EnrollInCourse(cs101);
            student2.EnrollInCourse(history101);

            student3.EnrollInCourse(math101);
            student3.EnrollInCourse(history101);

            // Create the course management system and add data
            CourseManagementSystem cms = new CourseManagementSystem();
            cms.AddCourse(math101);
            cms.AddCourse(cs101);
            cms.AddCourse(history101);

            cms.AddStudent(student1);
            cms.AddStudent(student2);
            cms.AddStudent(student3);

            // Use LINQ to get students enrolled in "CS 101"
            var studentsInCS101 = cms.GetStudentsEnrolledInCourse("CS 101");
            Console.WriteLine("Students enrolled in CS 101:");

            foreach (var student in studentsInCS101)
            {
                Console.WriteLine(student.GetFullName());
            }

            // Use LINQ to get the average credits per student
            var averageCredits = cms.GetAverageCreditsEnrolledByStudents();
            Console.WriteLine($"\nAverage credits per student: {averageCredits:F2}");

        }
    }
}
