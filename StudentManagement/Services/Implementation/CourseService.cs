using StudentManagement.Models;
using StudentManagement.Respositories.Interface;
using StudentManagement.Services.Interface;

namespace StudentManagement.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public CourseService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
        }

        public async Task<BaseResult<string>> AssignStudentToCourses(AssignCourseDto model)
        {
            try
            {
                var student = await _studentRepository.GetStudentById(model.StudentId);
                if (student is null)
                {
                    return new BaseResult<string>
                    {
                        IsError = true,
                        Message = "Student not found",
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }

                await _courseRepository.AssignCoursesToStudent(model);

                return new BaseResult<string>
                {
                    IsError = false,
                    Result = "Courses assigned successfully",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<string>
                {
                    IsError = true,
                    Exception = ex,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
