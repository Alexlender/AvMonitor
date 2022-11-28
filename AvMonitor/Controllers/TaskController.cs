using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AvMonitor.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;

        private readonly string _agentUri = "https://localhost:7284/Task";

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                string result = (await PostAsync(new Uri(_agentUri), task)).ToString();
                _logger.LogInformation(result);
            }
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskModel task)
        {
            string result = (await DeleteAsync(new Uri($"{_agentUri}/{task.Id}"))).ToString();
            _logger.LogInformation(result);
            return Redirect("/");
        }

        private static async Task<HttpStatusCode> PostAsync(Uri requestUri, object content)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(requestUri, content);
            return response.StatusCode;
        }

        private static async Task<HttpStatusCode> DeleteAsync(Uri requestUri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(requestUri);
            return response.StatusCode;
        }

    }
}
