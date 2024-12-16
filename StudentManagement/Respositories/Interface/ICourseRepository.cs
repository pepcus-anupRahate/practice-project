using StudentManagement.Entities;
using StudentManagement.Models;

namespace StudentManagement.Respositories.Interface
{
    public interface ICourseRepository
    {
        Task<Course?> GetCourseById(int courseId);
        Task<List<Course>> GetAllCourse();
        Task AddStudentCourse(int studentId, int courseId);
        Task<bool> AssignCoursesToStudent(AssignCourseDto model);
    }
}
