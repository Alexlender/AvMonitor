using Microsoft.AspNetCore.Mvc;
using Hangfire;
using AvMonitor;
using Agent.Classes;
using AvMonitor.Classes;
using AvMonitor.Models;
using System.Net;

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
        public ResponseModel CheckTask(TaskModel task)
        { 
            return Pinger.Ping(task.Path);
        }


        [HttpPost]
        [Route("add")]
        public IActionResult AddTask(TaskModel task)
        {
            
            ResponseModel response = Pinger.Ping(task);
            //await HttpManager.GetInstance().PostAsync($"add-response/{response.TaskId}", response);
            RecurringJob.AddOrUpdate(task.Id, () =>  HttpManager.GetInstance().PostAsync($"add-response/{response.TaskId}", response), task.CronExp); 
            return Ok(task.Id);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {

            RecurringJob.RemoveIfExists(id);
            return Ok();
        }

    }
}