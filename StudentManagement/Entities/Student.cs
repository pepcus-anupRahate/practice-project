namespace StudentManagement.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
