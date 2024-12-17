using Microsoft.EntityFrameworkCore;

namespace Web_PracticePoject.Models
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
            
        }
    }
}
