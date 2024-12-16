using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Entities;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;

namespace StudentManagement.Respositories.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public CourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Course?> GetCourseById(int courseId)
        {
            return await _context.Courses.FindAsync(courseId);
        }

        public async Task AddStudentCourse(int studentId, int courseId)
        {
            await _context.StudentCourses.AddAsync(new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            });
            await _context.SaveChangesAsync();
        }

        public async Task AssignCoursesToStudent(int studentId, List<int> courseIds)
        {
            foreach (var courseId in courseIds)
            {
                var course = await _context.Courses.FindAsync(courseId);
                if (course != null)
                {
                    _context.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = studentId,
                        CourseId = courseId
                    });
                }
            }
            _context.SaveChanges();
        }
    }
}
