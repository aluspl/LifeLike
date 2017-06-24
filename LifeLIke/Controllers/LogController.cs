using System;
using System.Linq;
using LifeLike.Models;
using LifeLike.ViewModel;
using LifeLIke.Repositories;
using LifeLIke.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class LogController : Controller
    {
        private readonly LifeLikeContext _context;
        private readonly IEventLogRepository _eventLogs;

        public LogController(LifeLikeContext context, IEventLogRepository eventLog)
        {
            _context = context;
            _eventLogs = eventLog;
        }
        // GET
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

        public IActionResult Detail(long id)
        {
            return View(_eventLogs.Get(id));
        }
    }
}