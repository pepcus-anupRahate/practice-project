using StudentManagement.Entities;
using StudentManagement.Models;

namespace StudentManagement.Services.Interface
{
    public interface IStudentService
    {
        Task<BaseResult<List<StudentDto>>> GetStudentsAsync();
        Task<BaseResult<string>> AddStudent(Student student);
    }
}
