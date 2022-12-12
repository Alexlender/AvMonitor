using Microsoft.AspNetCore.Mvc;
using Hangfire;
using AvMonitor;
using Agent.Classes;
using AvMonitor.Classes;
using AvMonitor.Models;
using System.Net;
using Hangfire.Common;

namespace Agent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("check")]
        public IActionResult CheckTask(TaskModel task)
        {
            Act(task);
            return Ok();
        }


        [HttpPost]
        [Route("add")]
        public IActionResult AddTask(TaskModel task)
        {

            //ResponseModel response = Pinger.Ping(task);
            //await HttpManager.GetInstance().PostAsync($"add-response/{response.TaskId}", response);
            System.Linq.Expressions.Expression<Action<TaskModel>> action = (task) => Console.WriteLine(task);
            RecurringJob.AddOrUpdate(task.Id, () => Act(task), task.CronExp);
            //RecurringJob.AddOrUpdate(task.Id, () => Console.WriteLine(DateTime.Now), task.CronExp); 
            return Ok(task.Id);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {

            RecurringJob.RemoveIfExists(id);
            return Ok();
        }

        static public void Act(TaskModel task)
        {

            ResponseModel response = Pinger.Ping(task);
            HttpManager.GetInstance().PostAsync($"add-response", response).Wait();
        }

    }
}