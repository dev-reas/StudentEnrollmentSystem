using Microsoft.AspNetCore.Mvc;
using StudentEnrollmentSystem.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentEnrollmentSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<StudentController> _logger;
        private readonly ApplicationDbContext _context;
        private static List<Student> _students = new List<Student>();

        public StudentController(ILogger<StudentController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound(); // Return 404 Not Found if the student with the given ID is not found
            }

            return Ok(student);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
            {
                return NotFound(); // Return 404 Not Found if the student with the given ID is not found
            }

            // Update the properties of the existing student with the values from updatedStudent
            existingStudent.stud_name = updatedStudent.stud_name;
            existingStudent.stud_course = updatedStudent.stud_course;
            existingStudent.Subject = updatedStudent.Subject;

            // Save changes to the database
            _context.SaveChanges();

            return NoContent(); // Return 204 No Content to indicate success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.stud_id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            _context.Students.Remove(existingStudent);
            _context.SaveChanges(); // Save changes to the database

            return NoContent();
        }
    }
}