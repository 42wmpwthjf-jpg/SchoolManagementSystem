using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Validation
{
    class StudentValidator
    {
        public bool IsIdUnique(int id, List<Student> students)
        {
            return !students.Any(s => s.ID == id);
        }
         public bool IsNameValid(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public bool IsGradeValid(int grade)
        {
            return grade >= 1 && grade <= 12;
        }

        public bool IsStatusValid(string status)
        {
            return status.ToLower() == "active" ||
                   status.ToLower() == "inactive";
        }
    }
}