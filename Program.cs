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

       
