using StudentServicesWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServicesWebApi.Data.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

        Student GetStudent(int id);

        bool AddNewStudent(Student student);

        List<Student> UpdateStudent(int id, Student student);

        bool DeleteStudent(int id);

        Student GetStudentByName(string name);

        List<Student> GetByFirstNameAndNumberOfCourses(string name, int numcourses);
    }
}
