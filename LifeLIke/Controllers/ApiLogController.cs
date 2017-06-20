using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.ApiModels;
using LifeLike.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    [Route("api/[controller]")]
    public class ApiLogController : Controller
    {
        private readonly LifeLikeContext _context;

        public ApiLogController(LifeLikeContext context)
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
                if (string.IsNullOrEmpty(model?.Messages)) return new BadRequestResult();
                _context.EventLogs.Add(EventLogDataModel.Generate(model));
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.EventLogs.Add(EventLogDataModel.Generate(e));
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
                _context.EventLogs.Add(EventLogDataModel.Generate(e));
                _context.SaveChanges();
            }
            return Ok();
        }
        
    }
}