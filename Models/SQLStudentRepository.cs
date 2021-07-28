using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagmen.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public SQLStudentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Student Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            Student student = context.Students.Find(id);
            if (student != null) {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        public Student GetStudent(int id)
        {
            return context.Students.Find(id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students;
        }

        public Student Update(Student updatestudent)
        {
            var student = context.Students.Attach(updatestudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatestudent;
        }
    }
}
