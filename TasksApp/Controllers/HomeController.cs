using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TasksApp.Models;

namespace TasksApp.Controllers
{
    public class HomeController : Controller
    {
        // Database context
        private TasksDatabaseContext _taskDbContext { get; set; }

        public HomeController(TasksDatabaseContext t)
        {
            _taskDbContext = t;
        }

        // Homepage
        public IActionResult Index()
        {
            return View();
        }

        // View tasks page
        public IActionResult ViewTasks()
        {
            var tasks = _taskDbContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.DueDate)
                .ToList();

            return View(tasks);
        }

        // Add new task form view
        [HttpGet]
        public IActionResult NewTask()
        {
            ViewBag.Categories = _taskDbContext.Categories.ToList();
            ViewBag.Header = "Add a new task";

            return View("NewTask", new Tasks());
        }

        // New task form submission
        [HttpPost]
        public IActionResult NewTask(Tasks t)
        {
            // Check if data is valid
            if (ModelState.IsValid)
            {
                _taskDbContext.Add(t);
                _taskDbContext.SaveChanges();

                return View("Confirmation", t);
            }

            // Data invalid, return back the form
            else
            {
                ViewBag.Categories = _taskDbContext.Categories.ToList();
                ViewBag.Header = "Add a new movie";

                return View(t);
            }
        }

        // Edit task form
        [HttpGet]
        public IActionResult EditTask(int TaskID)
        {
            // Grab task by id passed
            var task = _taskDbContext.Responses.Single(x => x.TaskID == TaskID);

            ViewBag.Categories = _taskDbContext.Categories.ToList();
            ViewBag.Header = $"Edit {task.TaskName}";

            // Return NewTask form with current task selected
            return View("NewTask", task);
        }

        // Edit form submission
        [HttpPost]
        public IActionResult EditTask(Tasks t)
        {
            // Check if data is valid
            if (ModelState.IsValid)
            {
                _taskDbContext.Update(t);
                _taskDbContext.SaveChanges();

                return RedirectToAction("ViewTasks"); // Redirect back to movies list
            }

            // Data invalid, return back the form
            else
            {
                ViewBag.Categories = _taskDbContext.Categories.ToList();
                ViewBag.Header = $"Edit {t.TaskName}";

                return View("NewTask", t);
            }
        }

        // Delete task confirmation page
        [HttpGet]
        public IActionResult DeleteTask(int TaskID)
        {
            // Grab selected task
            var task = _taskDbContext.Responses.Single(x => x.TaskID == TaskID);

            return View(task);
        }

        // Delete task form submission
        [HttpPost]
        public IActionResult DeleteTask(Tasks t)
        {
            _taskDbContext.Responses.Remove(t);
            _taskDbContext.SaveChanges();

            // Redirect back to tasks view
            return RedirectToAction("ViewTasks");
        }
    }
}
