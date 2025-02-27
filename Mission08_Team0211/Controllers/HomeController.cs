using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0211.Models;
using Task = Mission08_Team0211.Models.Task;

namespace Mission08_Team0211.Controllers
{
    public class HomeController : Controller
    {
        private TaskDbContext _context;

        public HomeController(TaskDbContext context)
        {
            _context = context;
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

        public IActionResult addTask()
        { 
            ViewBag.Categories = _context.Categories.OrderBy(x => x.Name).ToList();
            return View(new Task());
        }
    }
}
