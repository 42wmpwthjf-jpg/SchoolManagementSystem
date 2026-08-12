using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;
using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Application
{
    class SchoolManagementApp
    {
        private StudentService studentService;
        private TeacherService teacherService;

        public SchoolManagementApp()
        {
            List<Student> students = new List<Student>();
            studentService = new StudentService(students);

            List<Teacher> teachers = new List<Teacher>();
            teacherService = new TeacherService(teachers);
        }

        public void Run()
        {
            int choice = 0;

            while (choice != 9)
            {
                ShowMenu();

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ViewStudents();
                            break;

                        case 2:
                            AddStudent();
                            break;

                        case 3:
                            SearchStudents();
                            break;

                        case 4:
                            FilterStudents();
                            break;

                        case 5:
                            ViewTeachers();
                            break;

                        case 6:
                            AddTeacher();
                            break;

                        case 7:
                            ViewStudentInformation();
                            break;

                        case 8:
                            DisplayStatistics();
                            break;

                        case 9:
                            Console.WriteLine("Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(
                        "Invalid input. Please enter a number."
                    );
                }

                if (choice != 9)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private void ViewStudents()
        {
            studentService.ViewStudents();
        }

        private void AddStudent()
        {
            Console.Write("Enter student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student grade: ");

            if (!int.TryParse(Console.ReadLine(), out int grade))
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            Console.Write("Enter student status: ");
            string status = Console.ReadLine();

            string[] subjects = { "Java", "C++", "C#" };

            Student student = new Student(
                id,
                name,
                grade,
                subjects,
                status
            );

            if (studentService.AddStudent(student))
            {
                Console.WriteLine("Student added successfully.");
            }
        }

        private void SearchStudents()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            var foundStudents = studentService.SearchStudents(name);

            if (foundStudents.Count > 0)
            {
                foreach (Student student in foundStudents)
                {
                    student.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        private void FilterStudents()
        {
            Console.WriteLine("1. Filter by Grade");
            Console.WriteLine("2. Filter by Status");
            Console.Write("Enter filter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid filter choice.");
                return;
            }

            if (choice == 1)
            {
                Console.Write("Enter grade: ");

                if (!int.TryParse(Console.ReadLine(), out int grade))
                {
                    Console.WriteLine("Invalid grade.");
                    return;
                }

                var students = studentService.FilterByGrade(grade);

                foreach (Student student in students)
                {
                    student.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else if (choice == 2)
            {
                Console.Write("Enter status: ");
                string status = Console.ReadLine();

                var students = studentService.FilterByStatus(status);

                foreach (Student student in students)
                {
                    student.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid filter choice.");
            }
        }

        private void ViewTeachers()
        {
            teacherService.ViewTeachers();
        }

        private void AddTeacher()
        {
            Console.Write("Enter teacher ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid teacher ID.");
                return;
            }

            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine();

            string[] subjects = { "Java", "C++", "C#", "Web" };

            Teacher teacher = new Teacher(
                id,
                name,
                subjects
            );

            if (teacherService.AddTeacher(teacher))
            {
                Console.WriteLine("Teacher added successfully.");
            }
        }

        private void ViewStudentInformation()
        {
            Console.Write("Enter student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid student ID.");
                return;
            }

            Student student = studentService.GetStudentById(id);

            if (student != null)
            {
                student.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        private void DisplayStatistics()
        {
            studentService.DisplayStatistics();
        }

        private void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("===== School Management System =====");
            Console.WriteLine("1. View Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Search Students");
            Console.WriteLine("4. Filter Students");
            Console.WriteLine("5. View Teachers");
            Console.WriteLine("6. Add Teacher");
            Console.WriteLine("7. View Student Information");
            Console.WriteLine("8. Student Statistics");
            Console.WriteLine("9. Exit");

            Console.Write("Enter your choice: ");
        }
    }
}