using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementSystem.Models
{
    class Teacher : Person
    {
        public override void DisplayInfo() {
            Console.WriteLine("Teacher ID: " + ID);
            Console.WriteLine("Name: " + Name);
            foreach (string subject in Subjects)
            {
                Console.WriteLine("- " + subject);
            }
        }
        public string[] Subjects { get; set; }
        public Teacher(int id, string name, string[] subjects)
        {
            ID = id;
            Name = name;
            Subjects = subjects;
        }
    }
}