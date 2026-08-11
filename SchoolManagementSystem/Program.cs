using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();

            string[] studentSubjects = { "Java", "C++", "C#" };

            students.Add(new Student(
                101,
                "Raghad",
                10,
                studentSubjects,
                "Active"
            ));

            string[] teacherSubjects = { "Java", "C++", "C#", "Web" };

            teachers.Add(new Teacher(
                102,
                "Sara",
                teacherSubjects
            ));

            int choice = 0;

            while (choice != 8)
            {
                Console.Clear();

                Console.WriteLine("===== School Management System =====");
                Console.WriteLine("1. View Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Search Students");
                Console.WriteLine("4. Filter Students");
                Console.WriteLine("5. View Teachers");
                Console.WriteLine("6. View Student Information");
                Console.WriteLine("7. Student Statistics");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Students:");

                            foreach (Student student in students)
                            {
                                student.DisplayInfo();
                                Console.WriteLine();
                            }

                            break;

                        case 2:
                            Console.Write("Enter student ID: ");

                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.WriteLine("Invalid student ID.");
                                break;
                            }

                            if (students.Any(s => s.ID == id))
                            {
                                Console.WriteLine("Student ID already exists.");
                                break;
                            }

                            Console.Write("Enter student name: ");
                            string name = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Student name cannot be empty.");
                                break;
                            }

                            Console.Write("Enter student grade: ");

                            if (!int.TryParse(Console.ReadLine(), out int grade))
                            {
                                Console.WriteLine("Invalid grade.");
                                break;
                            }

                            if (grade < 1 || grade > 12)
                            {
                                Console.WriteLine("Grade must be between 1 and 12.");
                                break;
                            }

                            Console.Write("Enter student status: ");
                            string status = Console.ReadLine();

                            if (status.ToLower() != "active" &&
                                status.ToLower() != "inactive")
                            {
                                Console.WriteLine("Status must be Active or Inactive.");
                                break;
                            }

                            string[] subjects = { "Java", "C++", "C#" };

                            Student newStudent = new Student(
                                id,
                                name,
                                grade,
                                subjects,
                                status
                            );

                            students.Add(newStudent);

                            Console.WriteLine("Student added successfully.");
                            break;
                        case 3:
                            Console.Write("Enter student name: ");
                            string searchName = Console.ReadLine();

                            var foundStudents = students
                                .Where(s => s.Name.ToLower().Contains(searchName.ToLower()))
                                .ToList();

                            if (foundStudents.Count > 0)
                            {
                                Console.WriteLine("Sort results by:");
                                Console.WriteLine("1. ID");
                                Console.WriteLine("2. Name");
                                Console.WriteLine("3. Grade");
                                Console.Write("Enter sort choice: ");

                                if (int.TryParse(Console.ReadLine(), out int sortChoice))
                                {
                                    if (sortChoice == 1)
                                    {
                                        foundStudents = foundStudents
                                            .OrderBy(s => s.ID)
                                            .ToList();
                                    }
                                    else if (sortChoice == 2)
                                    {
                                        foundStudents = foundStudents
                                            .OrderBy(s => s.Name)
                                            .ToList();
                                    }
                                    else if (sortChoice == 3)
                                    {
                                        foundStudents = foundStudents
                                            .OrderBy(s => s.Grade)
                                            .ToList();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid sort choice.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid sort choice.");
                                }

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

                            break;

                        case 4:
                            Console.WriteLine("1. Filter by Grade");
                            Console.WriteLine("2. Filter by Status");
                            Console.Write("Enter filter choice: ");

                            if (!int.TryParse(
                                Console.ReadLine(),
                                out int filterChoice))
                            {
                                Console.WriteLine("Invalid filter choice.");
                                break;
                            }

                            if (filterChoice == 1)
                            {
                                Console.Write("Enter grade: ");

                                if (!int.TryParse(
                                    Console.ReadLine(),
                                    out int filterGrade))
                                {
                                    Console.WriteLine("Invalid grade.");
                                    break;
                                }

                                if (filterGrade < 1 || filterGrade > 12)
                                {
                                    Console.WriteLine(
                                        "Grade must be between 1 and 12."
                                    );
                                    break;
                                }

                                var filteredStudents = students
                                    .Where(s => s.Grade == filterGrade)
                                    .ToList();

                                if (filteredStudents.Count > 0)
                                {
                                    foreach (Student student in filteredStudents)
                                    {
                                        student.DisplayInfo();
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "No students found in this grade."
                                    );
                                }
                            }
                            else if (filterChoice == 2)
                            {
                                Console.Write("Enter status: ");
                                string filterStatus = Console.ReadLine();

                                var filteredStudents = students
                                    .Where(s =>
                                        s.Status.ToLower() ==
                                        filterStatus.ToLower())
                                    .ToList();

                                if (filteredStudents.Count > 0)
                                {
                                    foreach (Student student in filteredStudents)
                                    {
                                        student.DisplayInfo();
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "No students found with this status."
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid filter choice.");
                            }

                            break;

                        case 5:
                            Console.WriteLine("Teachers:");

                            foreach (Teacher teacher in teachers)
                            {
                                teacher.DisplayInfo();
                                Console.WriteLine();
                            }

                            break;

                        case 6:
                            Console.Write("Enter student ID: ");

                            if (!int.TryParse(
                                Console.ReadLine(),
                                out int studentId))
                            {
                                Console.WriteLine("Invalid student ID.");
                                break;
                            }

                            Student foundStudent = students
                                .FirstOrDefault(s => s.ID == studentId);

                            if (foundStudent != null)
                            {
                                foundStudent.DisplayInfo();
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }

                            break;

                        case 7:
                            Console.WriteLine("===== Student Statistics =====");

                            int totalStudents = students.Count;

                            int activeStudents = students.Count(
                                s => s.Status.ToLower() == "active"
                            );

                            int inactiveStudents = students.Count(
                                s => s.Status.ToLower() == "inactive"
                            );

                            Console.WriteLine(
                                $"Total Students: {totalStudents}"
                            );

                            Console.WriteLine(
                                $"Active Students: {activeStudents}"
                            );

                            Console.WriteLine(
                                $"Inactive Students: {inactiveStudents}"
                            );

                            var studentsPerGrade = students
                                .GroupBy(s => s.Grade)
                                .OrderBy(g => g.Key);

                            Console.WriteLine(
                                "\nStudents in each grade:"
                            );

                            foreach (var gradeGroup in studentsPerGrade)
                            {
                                Console.WriteLine(
                                    $"Grade {gradeGroup.Key}: " +
                                    $"{gradeGroup.Count()} student(s)"
                                );
                            }

                            break;

                        case 8:
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

                if (choice != 8)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}