using LifeLike.Services;
using LifeLike.Services.Structures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly ILogService _logger;

        public LogController(ILogService logger)
        {
            _logger = logger;
        }

        // GET
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _logger.List();
            return Ok(list);
        }  
        [Authorize]
        [HttpPost("Clear")]
        public IActionResult Clear()
        {
            var list = _logger.DeleteAll();
            return Ok(list);
        }
    }
}