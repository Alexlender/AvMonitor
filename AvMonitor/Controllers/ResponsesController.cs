using Microsoft.AspNetCore.Mvc;

namespace AvMonitor.Controllers
{
    public class ResponsesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
