using System;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
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
                await _logger.Add(EventLogApiModel.Generate(model));
            }
            catch (Exception e)
            {
                await  _logger.AddException(e);

                throw;
            }
            return Ok();
        }
       
        
    }
}