using AvMonitor.Data;
using AvMonitor.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvMonitor.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly TaskDataContext _context;

        public ResponsesController(TaskDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(TaskModel task)
        {
            ViewData["dbContext"] = _context;
            ViewData["task"] = task;

            return View();
        }
    }
}
