using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Repositories.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    
    [Route("api/[controller]")]
    public class SiteManagerController : Controller
    {
        private readonly IConfigRepository _config;

        private readonly IEventLogRepository _logger;

        public SiteManagerController(IConfigRepository configRepository, IEventLogRepository logger)
        {
            _config = configRepository;
            _logger = logger;
        }

        // GET
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetList()
        {
            var configs = await _config.List();
            return Ok(configs);
        }


        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Config model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                await _config.Create(model);
                 return Ok(); 
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
        [HttpGet("Update")]
        [Authorize]
        public async Task<IActionResult> Update(string id)
        {
            var model = await _config.Get(id);
            return Ok(model);
        }

        [HttpPut("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Config model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                await _config.Update(model);
                 return Ok(); 
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
    }
}