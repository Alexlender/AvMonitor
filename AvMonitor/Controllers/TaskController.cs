using AvMonitor.Classes;
using AvMonitor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvMonitor.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(User.Identity?.Name);
                string result = (await HttpManager.GetInstance().PostAsync("Task/add", task)).ToString();
                _logger.LogInformation(result);
            }
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskModel task)
        {
            Console.WriteLine($"{task.Id}");
            Console.WriteLine(await HttpManager.GetInstance().DeleteAsync($"Task/delete/{task.Id}"));
            return Redirect("/");
        }

    }
}
