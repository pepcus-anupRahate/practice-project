using Microsoft.AspNetCore.Mvc;
using Web_PracticePoject.Models;

namespace Web_PracticePoject.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskDbContext _context;

        public TaskController(TaskDbContext context)
        {
            _context = context;
        }

        // GET: /Task/
        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        // POST: /Task/Create
        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var task = new Models.Task { Name = name, IsCompleted = false };
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: /Task/Complete
        [HttpPost]
        public IActionResult Complete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsCompleted = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: /Task/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}