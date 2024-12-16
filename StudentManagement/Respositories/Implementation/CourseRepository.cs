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

        public async Task<List<Course>> GetAllCourse()
        {
            return await _context.Courses.ToListAsync();
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

        //public async Task AssignCoursesToStudent(int studentId, List<int> courseIds)
        //{
        //    foreach (var courseId in courseIds)
        //    {
        //        var course = await _context.Courses.FindAsync(courseId);
        //        if (course != null)
        //        {
        //            _context.StudentCourses.Add(new StudentCourse
        //            {
        //                StudentId = studentId,
        //                CourseId = courseId
        //            });
        //        }
        //    }
        //    _context.SaveChanges();
        //}

        public async Task<bool> AssignCoursesToStudent(AssignCourseDto model)
        {
            if (model.CourseIds == null || !model.CourseIds.Any())
            {
                return false;
            }
            var student = await _context.Students.FindAsync(model.StudentId);
            if (student == null)
            {
                return false;
            }
            bool allCoursesAssigned = true;
            foreach (var courseId in model.CourseIds)
            {
                var course = await _context.Courses.FindAsync(courseId);
                if (course != null)
                {
                    _context.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = model.StudentId,
                        CourseId = courseId
                    }); 
                }
                else
                {
                    allCoursesAssigned = false;
                }
            }
            if (allCoursesAssigned)
            {
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
