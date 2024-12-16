using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Entities;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;

namespace StudentManagement.Respositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }
        private static List<User> users = new List<User>
        {
           new User { Username = "admin", Password = "admin" },
           new User { Username = "teacher", Password = "teacher123" },
        };

        public User ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public async Task<Student?> GetStudentById(int studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .ToListAsync();
        }

        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}
