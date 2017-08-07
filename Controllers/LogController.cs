using System;
using System.Linq;
using LifeLike.Models;
using LifeLike.ViewModel;
using LifeLIke.Repositories;
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
        public IActionResult Index()
        {
            try
            {
                var list=_logger.List().Where(P=>P.Type!=EventLogType.Statistic).Select(EventLogViewModel.Get);
                return  View(list);

            }
            catch (Exception e)
            {
                 _logger.AddExceptionLog(e);
            }
            return View();
        }
        [Authorize]
        public IActionResult Detail(long id)
        {
            return View(_logger.Get(id));
        }
        [HttpGet]
        public IActionResult Clear()
        {
            _logger.ClearLogs();
            return RedirectToAction("Index");
        }
    }
}