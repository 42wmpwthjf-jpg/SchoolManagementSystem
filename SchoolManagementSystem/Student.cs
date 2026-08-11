using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SchoolManagementSystem
{
    class Student : Person
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Student ID: " + ID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Grade: " + Grade);
            Console.WriteLine("Status: " + Status);

            Console.WriteLine("Subjects:");

            foreach (string subject in Subjects)
            {
                Console.WriteLine("- " + subject);
            }
        }
       
        public int Grade { get; set; }
        public string[] Subjects { get; set; }
        public string Status { get; set; }

        public Student(int id, string name,int grade, string[] subjects, string status)
        {
            ID = id;
            Name = name;
            Grade = grade;
            Subjects = subjects;
            Status = status;
            
        }
    }
}


