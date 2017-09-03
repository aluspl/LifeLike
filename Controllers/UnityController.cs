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
    public class UnityController : Controller
    {
        private readonly IEventLogRepository _logger;

        public UnityController( IEventLogRepository logger)
        {
            _logger = logger;
        }
        // GET
       
        [HttpPost]
        public IActionResult Post(WebHookDataModel model)
        {
            try
            {
                _logger.AddStat("","Post", "Unity");

                if (model==null) return new BadRequestResult();
                _logger.Add(EventLog.Generate(model));
            }
            catch (Exception e)
            {
            _logger.AddExceptionLog(e);

                throw;
            }
            return Ok();
        }
       
        
    }
}