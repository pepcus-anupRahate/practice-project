using StudentManagement.Entities;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;
using StudentManagement.Services.Interface;

namespace StudentManagement.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<BaseResult<List<StudentDto>>> GetStudentsAsync()
        {
            try
            {
                var students = await _studentRepository.GetStudentsAsync();
                if (students is null || students.Count == 0)
                {
                    return new BaseResult<List<StudentDto>>
                    {
                        IsError = true,
                        Message = "Student not found",
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }

                var studentDtos = students.Select(s => new StudentDto
                {
                    Name = s.Name,
                    Email = s.Email,
                    Phone = s.Phone,
                    EnrolledCourses = string.Join(", ", s.StudentCourses.Select(sc => sc.Course.CourseName))
                }).ToList();

                return new BaseResult<List<StudentDto>>
                {
                    IsError = false,
                    Result = studentDtos,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<StudentDto>>
                {
                    IsError = true,
                    Exception = ex,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public async Task<BaseResult<string>> AddStudent(Student student)
        {
            try
            {
                if (student is null)
                {
                    return new BaseResult<string>
                    {
                        IsError = true,
                        Result = "Invalid data",
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

                await _studentRepository.AddStudent(student);
                return new BaseResult<string>
                {
                    IsError = false,
                    Result = "Student added successfully",
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
