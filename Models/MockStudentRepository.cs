using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagmen.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentsList;
        public MockStudentRepository()
        {
            _studentsList = new List<Student>()
            {
                new Student(){Id = 1, Name = "Allen Cai", ClassName= ClassNameEnum.FirstGrade, Email = "allencaidota@gmail.com"},
                new Student(){Id = 2, Name = "AB", ClassName= ClassNameEnum.SecondGrade, Email = "allencaidota@gmail.com"},
                new Student(){Id = 3, Name = "ABP", ClassName=ClassNameEnum.ThridGrade, Email = "allencaidota@gmail.com"}
            };

        }
        public Student Add(Student student)
        {
            student.Id = _studentsList.Max(s => s.Id) + 1;
            _studentsList.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _studentsList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _studentsList.Remove(student);
            }
            return student;
        }

        public Student GetStudent(int id)
        {
           return _studentsList.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentsList;
        }

        public Student Update(Student updateStudent)
        {
            Student student = _studentsList.FirstOrDefault(s => s.Id == updateStudent.Id);
            {
                if(student != null)
                {
                    student.Name = updateStudent.Name;
                    student.Email = updateStudent.Email;
                    student.ClassName = updateStudent.ClassName;
                }
                return student;
            }
        }
    }
}
