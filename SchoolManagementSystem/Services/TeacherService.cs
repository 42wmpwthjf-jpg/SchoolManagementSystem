using System.Collections.Generic;
using System.Linq;
using SchoolManagementSystem.Models;
using System;
using SchoolManagementSystem.Validation;
namespace SchoolManagementSystem.Services
{
    class TeacherService
    {
        private List<Teacher> teachers;
        private TeacherValidator validator;
        public TeacherService(List<Teacher> teachers)
        {
            this.teachers = teachers;
            validator = new TeacherValidator();
        }

        public List<Teacher> GetTeachers()
        {
            return teachers;
        }

        public bool AddTeacher(Teacher teacher)
        {
            if (teachers.Any(t => t.ID == teacher.ID))
            {
                Console.WriteLine("Teacher ID already exists.");
                return false;
            }

            if (!validator.IsValid(teacher))
            {
                return false;
            }

            teachers.Add(teacher);
            return true;
        }

        public Teacher GetTeacherById(int id)
        {
            return teachers.FirstOrDefault(t => t.ID == id);
        }
        public void ViewTeachers()
        {
            if (teachers.Count == 0)
            {
                Console.WriteLine("No teachers available.");
            }
            else
            {
                foreach (Teacher teacher in teachers)
                {
                    teacher.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }

        public bool TeacherIdExists(int id)
        {
            return teachers.Any(t => t.ID == id);
        }
    }
}