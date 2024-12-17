using Microsoft.AspNetCore.Mvc;
using Web_PracticePoject.Models;
using Task = Web_PracticePoject.Models.Task;

namespace Web_PracticePoject.Controllers
{
    public class ManageTaskController : Controller
    {
        private readonly TaskDbContext _context;

        public ManageTaskController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetTasks()
        {
            var tasks = _context.Tasks.ToList();
            return Json(tasks);
        }

        [HttpPost]
        public JsonResult CreateTask(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var task = new Task { Name = name, IsCompleted = false };
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult CompleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsCompleted = true;
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
