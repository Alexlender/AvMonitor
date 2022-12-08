using AvMonitor.Classes;
using AvMonitor.Data;
using AvMonitor.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvMonitor.Controllers
{
    public class ResponseController : Controller
    {

        private readonly TaskDataContext _context;
        DataBase db;
        public ResponseController(TaskDataContext context)
        {
            _context = context;
            db = new DataBase(_context);
        }

        [HttpPost("add-response")]
        public IActionResult Post([FromBody] ResponseModel response)
        {
            db.AddResponse(response);
            return Ok();
        }
    }
}
