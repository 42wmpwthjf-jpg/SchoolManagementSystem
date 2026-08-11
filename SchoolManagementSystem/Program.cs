using System;

namespace SchoolManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] subjects = { "Java", "C++", "C#" };

            Student student = new Student(
                101,
                "Raghad",
                10,
                subjects,
                "Active"
            );

            student.DisplayInfo();

            Console.WriteLine();

            string[] teacherSubjects = { "Java", "C++", "C#", "Web" };

            Teacher teacher = new Teacher(
                102,
                "Sara",
                teacherSubjects
            );

            teacher.DisplayInfo();

            Console.ReadLine();
        }
    }
}