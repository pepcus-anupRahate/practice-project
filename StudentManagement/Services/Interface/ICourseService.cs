using StudentManagement.Models;

namespace StudentManagement.Services.Interface
{
    public interface ICourseService
    {
        Task<BaseResult<string>> AssignStudentToCourses(AssignCourseDto model);
    }
}
