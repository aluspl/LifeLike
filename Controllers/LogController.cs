using System;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.ViewModel;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class LogController : Controller
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public LogController(PortalContext context, IEventLogRepository logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list=await _logger.List();
                
                return  View(list?.Where(P=>P.Type!=EventLogType.Statistic)
                    .Select(EventLogViewModel.Get));

            }
            catch (Exception e)
            {
                 await _logger.AddException(e);
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Detail(long id)
        {
            return View(await _logger.Get(id));
        }
        [HttpGet]
        public async Task<IActionResult> Clear()
        {
            await _logger.ClearLogs();
            return RedirectToAction("Index");
        }
    }
}