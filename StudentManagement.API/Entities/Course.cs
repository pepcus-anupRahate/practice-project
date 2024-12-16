namespace StudentManagement.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public required string CourseName { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
