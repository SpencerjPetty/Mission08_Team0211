using System.Diagnostics;
using Mission08_Team0211.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using Task = Mission08_Team0211.Models.Task;

public class HomeController : Controller
{
    private readonly IRepository _repo;

    public HomeController(IRepository repo)
    {
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
        var tasks = _repo.Tasks
            .Where(t => !t.Completed)
            .Include(t => t.Category) // Eager load the Category table
            .ToList();

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
        ViewBag.Categories = _repo.Categories;
        if (ModelState.IsValid)
        {
            _repo.AddTask(task);
            return RedirectToAction("Quadrant");
        }
        return View(task);
    }

    public IActionResult Edit(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null)
        {
            return RedirectToAction("Error");
        }
        ViewBag.Categories = _repo.Categories;
        return View("Create", task);
    }

    // POST: Save edited task
    [HttpPost]
    public IActionResult Edit(Task task)
    {
        if (ModelState.IsValid)
        {
            _repo.EditTask(task);
            return RedirectToAction("Quadrant");
        }
        ViewBag.Categories = _repo.Categories;
        return View("Create", task);
    }

    // POST: Confirm Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task != null)
        {
            _repo.DeleteTask(task);
        }
        return RedirectToAction("Quadrant");
    }

    public IActionResult Complete(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task != null)
        {
            task.Completed = true;
            _repo.EditTask(task);
        }
        return RedirectToAction("Quadrant");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

