using System;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly IEventLogRepository _logger;

        public LogController(PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            
        }

        // GET
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var list=await _logger.List();

                return Json(list.Where(p=>p.Type!=EventLogType.Statistic).Select(EventLogViewModel.Get));
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return null;
            }
        }
        //Get
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(long id)
        {
            try
            {
              var login=  User.Identity.IsAuthenticated;

                var log = await _logger.Get(id);
                return Ok ( EventLogViewModel.Get(log));
            }
            catch (Exception e)
            {
              await  _logger.AddException(e);      
              throw;
            }           
        }
        [Authorize]
        [HttpGet("Clear")]
        public async Task<IActionResult> Clear()
        {
            var list = await _logger.ClearLogs();
            return  Json(list);    
        }
    }
}