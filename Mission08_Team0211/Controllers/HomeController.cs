using System.Diagnostics;
using Mission08_Team0211.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Task = Mission08_Team0211.Models.Task;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repo;

    public HomeController(ILogger<HomeController> logger, IRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public IActionResult Index()
    {
        // Showing the main page or Quadrant View
        var tasks = _repo.Tasks.Where(t => !t.Completed).ToList();
        return View(tasks);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // List Tasks by Quadrant
    public IActionResult Quadrant()
    {
        var tasks = _repo.Tasks.Where(t => !t.Completed).ToList();
        return View(tasks);
    }

    // GET: Create a new task
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _repo.Categories;
        return View(new Task());
    }

    // POST: Save new task
    [HttpPost]
    public IActionResult Create(Task task)
    {
        if (ModelState.IsValid)
        {
            _repo.AddTask(task);
            return RedirectToAction("Tasks");
        }
        ViewBag.Categories = _repo.Categories;
        return View(task);
    }

    // GET: Edit Task
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null)
        {
            return NotFound();
        }
        ViewBag.Categories = _repo.Categories;
        return View(task);
    }

    // POST: Save edited task
    [HttpPost]
    public IActionResult Edit(Task task)
    {
        if (ModelState.IsValid)
        {
            _repo.EditTask(task);
            return RedirectToAction("Tasks");
        }
        ViewBag.Categories = _repo.Categories;
        return View(task);
    }

    // GET: Confirm Delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    // POST: Confirm Delete
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task != null)
        {
            _repo.DeleteTask(task);
        }
        return RedirectToAction("Tasks");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

