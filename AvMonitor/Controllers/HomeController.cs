using AvMonitor.Data;
using AvMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AvMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskDataContext _context;

        public HomeController(TaskDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            ViewData["dbContext"] = _context;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}