using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementSystem.Models
{
    abstract class Person
    {
        public abstract void DisplayInfo();
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
