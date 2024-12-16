using StudentManagement.Entities;
using StudentManagement.Models;

namespace StudentManagement.Respositories.Interface
{
    public interface ICourseRepository
    {
        Task<Course?> GetCourseById(int courseId);
        Task AddStudentCourse(int studentId, int courseId);
        Task AssignCoursesToStudent(int studentId, List<int> courseIds);
    }
}
