namespace StudentManagement.Models
{
    public class AssignCourseDto
    {
        public int StudentId { get; set; }
        public List<int> CourseIds { get; set; }
    }
}
