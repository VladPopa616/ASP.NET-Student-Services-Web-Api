using StudentServicesWebApi.Data.Interfaces;
using StudentServicesWebApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentServicesWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        public IStudentRepository students;

        public StudentsController()
        {

        }

        public StudentsController(IStudentRepository _students)
        {
            this.students = _students;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return students.GetAllStudents();
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var student = students.GetStudent(id);

            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult AddNewStudent(Student student)
        {
            bool result = students.AddNewStudent(student);

            if (result)
            {
                return Ok(students);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            if (students.DeleteStudent(id))
            {
                return Ok(students.GetAllStudents());
            }
            return NotFound();

        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            var ustudent = students.UpdateStudent(id, student);

            if(ustudent != null)
            {
                return Ok(ustudent);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/students/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            var student = students.GetStudentByName(name);

            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        [Route("api/students/{name}/{numcourses}")]
        public IHttpActionResult GetByFirstNameAndNumCourses(string name, int numcourses)
        {
            var studentList = students.GetByFirstNameAndNumberOfCourses(name, numcourses);

            if(studentList == null)
            {
                return NotFound();
            }
            return Ok(studentList);
        }

    }
}
