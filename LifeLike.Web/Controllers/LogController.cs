using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Services;
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

        public LogController( ILogService logger)
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
        //Get
        [HttpGet("Detail/{id}")]
        public IActionResult Detail(long id)
        {
         
                var log = _logger.Get(id);
                return Ok(log);         
        }
        [Authorize]
        [HttpGet("Clear")]
        public IActionResult Clear()
        {
            var list = _logger.ClearLogs();
            return Ok(list);
        }
    }
}