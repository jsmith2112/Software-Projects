using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challeng_1
{

        class Program
        {
            // Example method using 'in' parameter (cannot be modified inside)
            static void ShowSquare(in int number)
            {
                Console.WriteLine($"Square of {number} is {number * number}");
            }

            // Example method using 'out' parameter (must assign value inside)
            static void GetUserFullName(out string fullName)
            {
                Console.Write("Enter your first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter your last name: ");
                string lastName = Console.ReadLine();

                fullName = firstName + " " + lastName; // Combine names
            }

            // Example method using 'ref' parameter (modifies caller’s variable)
            static void AddBonus(ref int score, int bonus)
            {
                score += bonus; // Add bonus to score
                Console.WriteLine($"Score after bonus: {score}");
            }

            // A simple class with automatic get/set properties
            class Student
            {
                public string name { get; set; }
                public int age { get; set; }
            }

            static void Main(string[] args)
            {
                // --- Demonstrate 'in' ---
                Console.Write("Enter a number to square: ");
                int num = int.Parse(Console.ReadLine());
                ShowSquare(in num);

                // --- Demonstrate 'out' ---
                GetUserFullName(out string fullName);
                Console.WriteLine($"Hello, {fullName}!");

                // --- Demonstrate 'ref' ---
                Console.Write("Enter your score: ");
                int score = int.Parse(Console.ReadLine());
                AddBonus(ref score, 10);

                // --- Demonstrate automatic get/set ---
                Student student = new Student();
                Console.Write("Enter student name: ");
                student.name = Console.ReadLine();
                Console.Write("Enter student age: ");
                student.age = int.Parse(Console.ReadLine());

                Console.WriteLine($"Student Info: Name = {student.name}, Age = {student.age}");
            }
        }


    }

