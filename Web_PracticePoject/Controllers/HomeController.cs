using System.Diagnostics;
using Fingers10.ExcelExport.ActionResults;
using Microsoft.AspNetCore.Mvc;
using Web_PracticePoject.Models;
using Web_PracticePoject.Services;

namespace Web_PracticePoject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDemoService _demoService;

        public HomeController(ILogger<HomeController> logger, IDemoService demoService)
        {
            _demoService = demoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetExcel()
        {
            // Get you IEnumerable<T> data
            var results = await _demoService.GetAllData();
            return new ExcelResult<DemoExcel>(results, "Demo Sheet Name", "Fingers10");
        }

        public async Task<IActionResult> OnGetExcelAsync()
        {
            // Get you IEnumerable<T> data
            var results = await _demoService.GetAllData();
            return new ExcelResult<DemoExcel>(results, "Demo Sheet Name", "Fingers10");
        }
    }
}
