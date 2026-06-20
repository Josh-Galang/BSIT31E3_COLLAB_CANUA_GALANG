using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Student
    {
        private string name;
        private List<int> grades;


        public Student(string name, List<int> grades)
        {
            this.name = name;
            this.grades = grades;
        }

        public string GetName()
        {
            return name;
        }

        public List<int> GetGrades()
        {
            return grades;
        }

        public double GetAverage()
        {
            if (grades.Count == 0)
                return 0;

            double sum = 0;

            foreach (int grade in grades)
            {
                sum += grade;
            }

            return sum / grades.Count;
        }
    }

    class Program
    {
        private List<Student> students = new List<Student>();


        public void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                DisplayMenu();
                int choice = GetMenuChoice();

                if (choice == 1)
                    AddStudent();
                else if (choice == 2)
                    ViewAllStudents();
                else if (choice == 3)
                    ComputeAvgGrades();
                else if (choice == 4)
                    FindHighestGrade();
                else if (choice == 5)
                {
                    running = false;
                    Console.WriteLine("Exiting Program...");
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid Choice. Choose 1-5 only.\n");
                }
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");
        }

        public int GetMenuChoice()
        {
            string input = Console.ReadLine();
            try
            {
                return int.Parse(input);
            }
            catch
            {
                return 0;
            }
        }

        public void AddStudent()
        {
            Console.WriteLine();

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            List<int> grades = new List<int>();

            Console.Write("Enter grade 1: ");
            grades.Add(int.Parse(Console.ReadLine()));

            Console.Write("Enter grade 2: ");
            grades.Add(int.Parse(Console.ReadLine()));

            Console.Write("Enter grade 3: ");
            grades.Add(int.Parse(Console.ReadLine()));

            Student student = new Student(name, grades);
            students.Add(student);

            Console.WriteLine("Student added successfully!\n");
        }

        public void ViewAllStudents()
        {
            Console.WriteLine();
            if (students.Count == 0)
            {
                Console.WriteLine("No student in the system.\n");
                return;
            }

            Console.WriteLine("======= ALL STUDENTS ======");

            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.GetName()}");
                Console.WriteLine($"Grades: {string.Join(", ", student.GetGrades())}");
                Console.WriteLine($"Average: {student.GetAverage():F2}");
                Console.WriteLine();
            }
        }

        public void ComputeAvgGrades()
        {
            Console.WriteLine();
            if (students.Count == 0)
            {
                Console.WriteLine("No student in the system.\n");
                return;
            }

            double totalAverage = 0;
            foreach (Student student in students)
            {
                totalAverage += student.GetAverage();
            }

            double classAverage = totalAverage / students.Count;

            Console.WriteLine("===== CLASS AVERAGE =====");
            Console.WriteLine($"Overall Average Grade: {classAverage:F2}\n");
        }

        public void FindHighestGrade()
        {
            Console.WriteLine();
            if (students.Count == 0)
            {
                Console.WriteLine("No student in the system.\n");
                return;
            }

            Student topStudent = null;
            int highestGrade = -1;

            foreach (Student student in students)
            {
                foreach (int grade in student.GetGrades())
                {
                    if (grade > highestGrade)
                    {
                        highestGrade = grade;
                        topStudent = student;
                    }
                }
            }

            Console.WriteLine("===== HIGHEST GRADE =====");
            Console.WriteLine($"Top Student: {topStudent.GetName()}");
            Console.WriteLine($"Highest Grade: {highestGrade}\n");
        }
    }
}
