using StudentServicesWebApi.Data.Interfaces;
using StudentServicesWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServicesWebApi.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> students = new List<Student>()
        {
            new Student {Id = 1, FirstName = "John", LastName = "Doe", GraduationDate = DateTime.Today, NoOfCourses=7},
            new Student {Id = 2, FirstName = "Mary", LastName = "Moore", GraduationDate = DateTime.Today, NoOfCourses=8},
            new Student {Id = 3, FirstName = "Patrick", LastName = "Johnson", GraduationDate = DateTime.Today, NoOfCourses=6},
            new Student {Id = 4, FirstName = "Sarah", LastName = "Thompson", GraduationDate = DateTime.Today, NoOfCourses=5},
            new Student {Id = 5, FirstName = "Peter", LastName = "Smith", GraduationDate = DateTime.Today, NoOfCourses=7},
            new Student {Id = 6, FirstName = "Jennifer", LastName = "", GraduationDate = DateTime.Today, NoOfCourses=8}
        };
        public bool AddNewStudent(Student student)
        {
            students.Add(student);
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudent(id);

            if(student == null)
            {
                return false;
            }
            students.Remove(student);
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public List<Student> GetByFirstNameAndNumberOfCourses(string name, int numcourses)
        {
            return students.Where(x => x.FirstName.Contains(name) && x.NoOfCourses == numcourses).ToList();
        }

        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public Student GetStudentByName(string name)
        {
            return students.FirstOrDefault(x => x.LastName == name);
        }

        public List<Student> UpdateStudent(int id, Student student)
        {
            if (this.DeleteStudent(id))
            {
                this.AddNewStudent(student);
                return students;
            }
            return students;
        }
    }
}
