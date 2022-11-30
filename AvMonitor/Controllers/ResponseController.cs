using AvMonitor.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvMonitor.Controllers
{
    public class ResponseController : Controller
    {
        [HttpPost("add-response/{id}")]
        public IActionResult Post(ResponseModel response)
        {
            Console.WriteLine($"Task {response.TaskId} was checked at {response.DateTime} with result {response.StatusCode}");
            return Ok();
        }
    }
}
