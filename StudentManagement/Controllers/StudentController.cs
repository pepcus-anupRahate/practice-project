using Microsoft.AspNetCore.Mvc;
using StudentManagement.Entities;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: Display the form to add a student
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View(); // Returns the view for adding a student
        }

        /// <summary>
        /// Adds a new student to the system.
        /// </summary>
        /// <param name="student">The student object to add.</param>
        /// <returns>A message indicating success or failure.</returns>
        //POST: https://localhost:7265/Student/add

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = studentDto.Name,
                    Email = studentDto.Email,
                    Phone = studentDto.Phone
                };
                await _studentRepository.AddStudent(student); // Add student to the repository
                return RedirectToAction("list"); // Redirect to the student list page
            }
            return View(studentDto); // If model validation fails,
        }

        /// <summary>
        /// Retrieves a list of all students, including their enrolled courses.
        /// </summary>
        /// <returns>A list of students with enrolled courses.</returns>
        //GET: https://localhost:7265/Student/list
        [HttpGet("list")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudentsAsync();
            var studentDtos = students.Select(s => new StudentDto
            {
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                EnrolledCourses = string.Join(", ", s.StudentCourses.Select(sc => sc.Course.CourseName))
            }).ToList();

            return View(studentDtos);
        }


    }
}
