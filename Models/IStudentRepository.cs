using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagmen.Models
{
    public interface IStudentRepository
    {
        //get info of student
        Student GetStudent(int id);
        //get all students info
        IEnumerable<Student> GetStudents();
        //add student to list
        Student Add(Student student);
        //update student info
        Student Update(Student updatestudent);
        //delete one student information
        Student Delete(int id);
    }
}
