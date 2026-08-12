using System;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Validation
{
    class TeacherValidator
    {
        public bool IsValid(Teacher teacher)
        {
            if (teacher.ID <= 0)
            {
                Console.WriteLine("Teacher ID must be greater than 0.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(teacher.Name))
            {
                Console.WriteLine("Teacher name cannot be empty.");
                return false;
            }

            return true;
        }
    }
}