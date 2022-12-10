using AvMonitor.Classes;
using AvMonitor.Data;
using AvMonitor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvMonitor.Controllers
{

    public class TaskController : Controller
    {
       
        private readonly TaskDataContext _context;
        DataBase db;
        public TaskController(TaskDataContext context)
        {
            _context = context;
            db = new DataBase(_context);
        }


        [HttpPost]
        public async Task<IActionResult> Add(TaskModel task)
        {
            task.UserName = User.Identity?.Name;
            if (ModelState.IsValid)
            {
                if (db.GetTaskByID(task.Id) == null)
                {
                    db.AddTask(task);
                    string result = (await HttpManager.GetInstance().PostAsync("Task/add", task)).ToString();
                    Console.WriteLine(result);
                    return Redirect("/Home/TaskEdit");
                }
                
            }
            Console.WriteLine("ERROR");
            return Redirect("/Home/TaskEdit");

        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]TaskModel task)
        {
            task.UserName = User.Identity?.Name;
            db.DeleteTaskByID(task.Id);
            Console.WriteLine(await HttpManager.GetInstance().DeleteAsync($"Task/delete/{task.Id}"));
            return Redirect("/Home/TaskEdit");
        }

    }
}
