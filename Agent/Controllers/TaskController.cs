using Microsoft.AspNetCore.Mvc;

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
        public Task Get()
        {
            return new Task() { Date = DateTime.Now };
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public bool Post(IEnumerable<Task> tasks)
        {
            return tasks.First().TemperatureC == 10;
        }

    }
}