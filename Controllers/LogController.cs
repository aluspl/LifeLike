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
        private readonly IEventLogRepository _eventLogs;

        public LogController(PortalContext context, IEventLogRepository eventLog)
        {
            _context = context;
            _eventLogs = eventLog;
        }
        // GET
        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var list=_eventLogs.List().Select(EventLogViewModel.Get);
                return  View(list);

            }
            catch (Exception e)
            {
                 _eventLogs.AddExceptionLog(e);
            }
            return View();

        }
        [Authorize]
        public IActionResult Detail(long id)
        {
            return View(_eventLogs.Get(id));
        }
        [HttpGet]
        public IActionResult Clear()
        {
            _eventLogs.ClearLogs();
            return RedirectToAction("Index");
        }
    }
}