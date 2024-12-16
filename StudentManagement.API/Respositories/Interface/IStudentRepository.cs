using StudentManagement.Entities;
using StudentManagement.Models;

namespace StudentManagement.Respositories.Interface
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudentById(int studentId);
        Task<List<Student>> GetStudentsAsync();
        Task AddStudent(Student student);
    }
}
