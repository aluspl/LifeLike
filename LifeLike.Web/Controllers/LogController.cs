using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;

namespace LifeLike.Web.Controllers
{
    [Route("Log")]
    public class LogController : Controller
    {
        private readonly IEventLogRepository _logger;

        public LogController(PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        
        [HttpGet("Details")]
        public async Task<IActionResult> Detail(long id)
        {
            return Json ( EventLogViewModel
                .Get(await _logger.Get(id)));
        }
        [HttpGet("Clear")]
        public async Task<IActionResult> Clear()
        {
            var list = await _logger.ClearLogs();
            return  Json(list);    
        }
    }
}