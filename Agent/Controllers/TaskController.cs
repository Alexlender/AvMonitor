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

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        { 
            return Ok();
        }

        [HttpPost(Name = "add-task")]
        public async Task<IActionResult> PostAsync(TaskModel task)
        {
            ResponseModel response = new(HttpStatusCode.OK, task.Id);
            _ = await HttpManager.GetInstance().PostAsync($"add-response/{response.TaskId}", response);
            RecurringJob.AddOrUpdate(task.Id, () => HttpManager.GetInstance().PostAsync($"add-response/{response.TaskId}", response), task.CronExp); 
            return Ok(task.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            RecurringJob.RemoveIfExists(id);
            return Ok();
        }

    }
}