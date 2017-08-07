using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.ApiModels;
using LifeLike.Models;
using LifeLIke.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
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
            _logger.AddStat("","Index", "API Log");

            return Ok(_context.EventLogs.ToList());
        }
        [HttpPost]
        public IActionResult Post(EventLogApiModel model)
        {
            try
            {
                _logger.AddStat("","Post", "API Log");

                if (string.IsNullOrEmpty(model?.Messages)) return new BadRequestResult();
                _context.EventLogs.Add(EventLog.Generate(model));
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();

                throw;
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                foreach (var eventLogDataModel in _context.EventLogs)
                {
                    _context.Remove(eventLogDataModel);
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
            }
            return Ok();
        }
        
    }
}