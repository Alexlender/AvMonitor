using Microsoft.AspNetCore.Mvc;
using Hangfire;
using AvMonitor;

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
        public IActionResult Post(TaskModel task)
        {
            RecurringJob.AddOrUpdate(task.Id, () => Console.WriteLine($"PING {task.Url}"), task.CronExp); 
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