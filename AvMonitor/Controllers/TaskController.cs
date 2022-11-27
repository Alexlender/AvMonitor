using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AvMonitor.Controllers
{
    public class TaskController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Add(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(await PostAsync(new Uri("https://localhost:7284/Task"), task));
            }
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskModel task)
        {
            Console.WriteLine(task.Id);
            Console.WriteLine(await DeleteAsync(new Uri($"https://localhost:7284/Task/{task.Id}")));
            return Redirect("/");
        }

        private static async Task<HttpStatusCode> PostAsync(Uri requestUri, Object content)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(requestUri, content);
            return response.StatusCode;
        }

        private static async Task<HttpStatusCode> DeleteAsync(Uri requestUri)
        {
            var httpClient = new HttpClient();
            Console.WriteLine(requestUri);
            var response = await httpClient.DeleteAsync(requestUri);
            return response.StatusCode;
        }

    }
}
