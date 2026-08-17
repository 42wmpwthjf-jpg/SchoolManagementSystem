using System;
using System.Collections.Generic;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;
using SchoolManagementSystem.Constants;

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
            List<Student> students = studentService.GetStudents();

            DisplayStudents(students);
        }

        private void DisplayStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (Student student in students)
            {
                student.DisplayInfo();
                Console.WriteLine();
            }
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

            Student student = new Student(
                id,
                name,
                grade,
                SchoolConstants.StudentSubjects,
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

            List<Student> students = studentService.SearchStudents(name);

            DisplayStudents(students);
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
                FilterByGrade();
            }
            else if (choice == 2)
            {
                FilterByStatus();
            }
            else
            {
                Console.WriteLine("Invalid filter choice.");
            }
        }

        private void FilterByGrade()
        {
            Console.Write("Enter grade: ");

            if (!int.TryParse(Console.ReadLine(), out int grade))
            {
                Console.WriteLine("Invalid grade.");
                return;
            }

            List<Student> students = studentService.FilterByGrade(grade);

            DisplayStudents(students);
        }

        private void FilterByStatus()
        {
            Console.Write("Enter status: ");
            string status = Console.ReadLine();

            List<Student> students = studentService.FilterByStatus(status);

            DisplayStudents(students);
        }

        private void ViewTeachers()
        {
            List<Teacher> teachers = teacherService.GetTeachers();

            if (teachers.Count == 0)
            {
                Console.WriteLine("No teachers available.");
                return;
            }

            foreach (Teacher teacher in teachers)
            {
                teacher.DisplayInfo();
                Console.WriteLine();
            }
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

            Teacher teacher = new Teacher(
                id,
                name,
                SchoolConstants.TeacherSubjects
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
            Console.WriteLine("===== Student Statistics =====");

            int totalStudents = studentService.GetTotalStudents();
            int activeStudents = studentService.GetActiveStudents();
            int inactiveStudents = studentService.GetInactiveStudents();

            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Active Students: {activeStudents}");
            Console.WriteLine($"Inactive Students: {inactiveStudents}");

            var studentsPerGrade = studentService.GetStudentsPerGrade();

            Console.WriteLine("\nStudents in each grade:");

            foreach (var gradeGroup in studentsPerGrade)
            {
                Console.WriteLine(
                    $"Grade {gradeGroup.Key}: " +
                    $"{gradeGroup.Count()} student(s)"
                );
            }
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
