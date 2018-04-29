using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly IEventLogRepository _logger;
        private readonly IMapper _mapper;

        public LogController( IEventLogRepository logger, IMapper mapper)
        {
            _logger = logger;
            _mapper=mapper;
            
        }

        // GET
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var list=await _logger.List();
                var items=list.Select(_mapper.Map<EventLogViewModel>);
                return Ok(items);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
        //Get
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(long id)
        {
            try
            {
              var login=  User.Identity.IsAuthenticated;

                var log = await _logger.Get(id);
                return Ok ( _mapper.Map<EventLogViewModel>(log));
            }
            catch (Exception e)
            {
              await  _logger.AddException(e);      
                return StatusCode(500);
            }           
        }
        [Authorize]
        [HttpGet("Clear")]
        public async Task<IActionResult> Clear()
        {
            var list = await _logger.ClearLogs();
            return  Ok(list);    
        }
    }
}