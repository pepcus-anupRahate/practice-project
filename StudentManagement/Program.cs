using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Entities;
using StudentManagement.Respositories.Implementation;
using StudentManagement.Respositories.Interface;
using StudentManagement.Services.Implementation;
using StudentManagement.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();



builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseInMemoryDatabase("SchoolDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

// Call the seeding method
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
    SeedData(context);
}


app.Run();

void SeedData(SchoolDbContext context)
{
    if (!context.Students.Any())
    {
        // Seed Courses
        context.Courses.AddRange(
            new Course { Id = 1, CourseName = "Mathematics" },
            new Course { Id = 2, CourseName = "Physics" },
            new Course { Id = 3, CourseName = "Computer Science" }
        );

        // Seed Students
        context.Students.AddRange(
            new Student { Id = 1, Name = "Anup Rahate", Email = "anup.rahate@ex.com", Phone = "1234567890" },
            new Student { Id = 2, Name = "Vishal Bhai", Email = "vishal.bhai@ex.com", Phone = "0987654321" },
            new Student { Id = 3, Name = "Mohan Sharma", Email = "mohan.sharma@ex.com", Phone = "5432109876" }
        );

        // Seed StudentCourse relationships
        context.StudentCourses.AddRange(
            new StudentCourse { StudentId = 1, CourseId = 1 },
            new StudentCourse { StudentId = 1, CourseId = 2 },
            new StudentCourse { StudentId = 2, CourseId = 3 }
        );

        // Save changes to context
        context.SaveChanges();
    }
}