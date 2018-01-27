using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.ApiModels;
using LifeLike.Models;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    [Route("api/[controller]")]
    public class ApiLogController : Controller
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public ApiLogController(PortalContext context, IEventLogRepository logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            _logger?.AddStat(string.Empty,"Index", "API Log");

            return Ok(_context.EventLogs.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Post(EventLogApiModel model)
        {
            try
            {
                await _logger?.AddStat(string.Empty,"Post", "API Log");

                if (string.IsNullOrEmpty(model?.Messages)) return new BadRequestResult();
                await  _logger.Add(EventLog.Generate(model));
            
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            try
            {
                await _logger.DeleteAll();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
            }
            return Ok();
        }
        
    }
}