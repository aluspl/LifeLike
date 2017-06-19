using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.ApiMOdels;
using LifeLike.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly LifeLikeContext _context;

        public LogController(LifeLikeContext context)
        {
            _context = context;
        }
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.EventLogs.ToList());
        }
        [HttpPost]
        public IActionResult Post(EventLogApiModel model)
        {
            try
            {
                if (model == null) return new BadRequestResult();
                _context.EventLogs.Add(EventLogDataModel.Generate(model));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Ok();
        }
    }
}