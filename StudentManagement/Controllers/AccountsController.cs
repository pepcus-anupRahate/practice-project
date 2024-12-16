using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Respositories.Interface;

namespace StudentManagement.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public AccountsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto model)
        {
            var user = _studentRepository.ValidateUser(model.Username, model.Password);
            if (user != null)
            {
                return RedirectToAction("GetStudents", "Student");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid login credentials.";
                return View();
            }
        }

        // Logout
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}

