using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models;
using StudentManagement.Entities;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;
using StudentManagement.Services.Interface;

namespace StudentManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(ILogger<CourseController> logger, IStudentService studentService) : base(logger)
        {
            this._studentService = studentService;
        }

        /// <summary>
        /// Adds a new student to the system.
        /// </summary>
        /// <param name="student">The student object to add.</param>
        /// <returns>A message indicating success or failure.</returns>
        //POST: https://localhost:7265/api/Student/add
        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDto student)
        {
            var serviceResult = await _studentService.AddStudent(student);
            return HandleResponse(serviceResult);
        }

        /// <summary>
        /// Retrieves a list of all students, including their enrolled courses.
        /// </summary>
        /// <returns>A list of students with enrolled courses.</returns>
        
        //GET: https://localhost:7265/api/Student/list
        [HttpGet("list")]
        public async Task<IActionResult> GetStudents()
        {
            var serviceResult = await _studentService.GetStudentsAsync();
            return HandleResponse(serviceResult);
        }
    }
}
