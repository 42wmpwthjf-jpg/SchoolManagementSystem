using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Validation;

namespace SchoolManagementSystem.Services
{
    class StudentService
    {
        private List<Student> students;
        private StudentValidator validator;

        public StudentService(List<Student> students)
        {
            this.students = students;
            validator = new StudentValidator();
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public bool AddStudent(Student student)
        {
            if (!validator.IsIdUnique(student.ID, students))
            {
                return false;
            }

            if (!validator.IsNameValid(student.Name))
            {
                return false;
            }

            if (!validator.IsGradeValid(student.Grade))
            {
                return false;
            }

            if (!validator.IsStatusValid(student.Status))
            {
                return false;
            }

            students.Add(student);
            return true;
        }

        public List<Student> SearchStudents(string name)
        {
            return students
                .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        public List<Student> FilterByGrade(int grade)
        {
            return students
                .Where(s => s.Grade == grade)
                .ToList();
        }

        public List<Student> FilterByStatus(string status)
        {
            return students
                .Where(s => s.Status.ToLower() == status.ToLower())
                .ToList();
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.ID == id);
        }

        public List<Student> SortById(List<Student> students)
        {
            return students
                .OrderBy(s => s.ID)
                .ToList();
        }

        public List<Student> SortByName(List<Student> students)
        {
            return students
                .OrderBy(s => s.Name)
                .ToList();
        }

        public List<Student> SortByGrade(List<Student> students)
        {
            return students
                .OrderBy(s => s.Grade)
                .ToList();
        }

        public int GetTotalStudents()
        {
            return students.Count;
        }

        public int GetActiveStudents()
        {
            return students.Count(
                s => s.Status.ToLower() == "active"
            );
        }

        public int GetInactiveStudents()
        {
            return students.Count(
                s => s.Status.ToLower() == "inactive"
            );
        }

        public IEnumerable<IGrouping<int, Student>> GetStudentsPerGrade()
        {
            return students
                .GroupBy(s => s.Grade)
                .OrderBy(g => g.Key);
        }
    }
}