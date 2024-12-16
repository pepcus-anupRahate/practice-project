using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public CourseController(ILogger<CourseController> logger, ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult AssignCourse(int studentId)
        {
            var student = _studentRepository.GetStudentById(studentId);
            var courses = _courseRepository.GetAllCourse();
            ViewBag.Courses = courses;
            return View(student);
        }

        /// <summary>
        /// Assigns a list of courses to a student.
        /// </summary>
        /// <param name="model">The assignment details, including the student ID and list of course IDs.</param>
        /// <returns>A message indicating success or failure.</returns>
        [HttpPost("assign")]
        public async Task<IActionResult> AssignStudentToCourses([FromBody] AssignCourseDto model)
        {
            var addCources = await _courseRepository.AssignCoursesToStudent(model);
            return View();
        }
    }
}
