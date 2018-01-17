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
    public class UnityController : Controller
    {
        private readonly IEventLogRepository _logger;

        public UnityController( IEventLogRepository logger)
        {
            _logger = logger;
        }
        // GET
       
        [HttpPost]
        public async Task<IActionResult> Post(WebHookDataModel model)
        {
            try
            {
                await _logger.AddStat("","Post", "Unity");

                if (model==null) return new BadRequestResult();
                await _logger.Add(EventLog.Generate(model));
            }
            catch (Exception e)
            {
                await  _logger.AddExceptionLog(e);

                throw;
            }
            return Ok();
        }
       
        
    }
}