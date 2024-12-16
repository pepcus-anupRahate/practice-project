using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;
using StudentManagement.Services.Interface;

namespace StudentManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService) : base(logger)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Assigns a list of courses to a student.
        /// </summary>
        /// <param name="model">The assignment details, including the student ID and list of course IDs.</param>
        /// <returns>A message indicating success or failure.</returns>
        [HttpPost("assign")]
        public async Task<IActionResult> AssignStudentToCourses([FromBody] AssignCourseDto model)
        {
            var serviceesult = await _courseService.AssignStudentToCourses(model);
            return HandleResponse(serviceesult);
        }
    }
}
