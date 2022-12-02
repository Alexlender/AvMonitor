using AvMonitor.Classes;
using AvMonitor.Data;
using AvMonitor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvMonitor.Controllers
{
    public class TaskController : Controller
    {
       
        private readonly TaskDataContext _context;

        public TaskController(TaskDataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Add(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                var db = new DataBase(_context);
                Console.WriteLine(db.GetTaskByID("Vas.yandex").CronExp);

                Console.WriteLine(User.Identity?.Name);
                string result = (await HttpManager.GetInstance().PostAsync("Task/add", task)).ToString();
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
