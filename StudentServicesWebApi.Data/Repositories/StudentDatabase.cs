using StudentServicesWebApi.Data.Interfaces;
using StudentServicesWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServicesWebApi.Data.Repositories
{
    public class StudentDatabase : IStudentRepository
    {
        private StudentContext db = new StudentContext();
        public bool AddNewStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudent(id);

            if(student == null)
            {
                return false;
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public List<Student> GetByFirstNameAndNumberOfCourses(string name, int numcourses)
        {
            return db.Students.Where(x => x.FirstName.Contains(name) && x.NoOfCourses == numcourses).ToList();
        }

        public Student GetStudent(int id)
        {
            return db.Students.FirstOrDefault(x => x.Id == id);
        }

        public Student GetStudentByName(string name)
        {
            return db.Students.FirstOrDefault(x => x.LastName == name);
        }

        public List<Student> UpdateStudent(int id, Student student)
        {
            if (this.DeleteStudent(id))
            {
                this.AddNewStudent(student);
                db.SaveChanges();
                return db.Students.ToList();
            }
            return db.Students.ToList();
        }
    }
}
