using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Services;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    
    [Route("api/[controller]")]
    public class SiteManagerController : Controller
    {
        private readonly IConfigService _config;

        public SiteManagerController(IConfigService configRepository)
        {
            _config = configRepository;
        }

        // GET
        [HttpGet]
        [Authorize]
        public IActionResult GetList()
        {
            var configs = _config.List();
            return Ok(configs);
        }


        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Config model)
        {
            if (!ModelState.IsValid) return BadRequest();
            _config.Create(model);
            return Ok();
        }
        [HttpGet("Update")]
        [Authorize]
        public IActionResult Update(string id)
        {
            var model = _config.Get(id);
            return Ok(model);
        }

        [HttpPut("Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Config model)
        {
            if (!ModelState.IsValid) return BadRequest();
            _config.Update(model);
            return Ok();
        }
    }
}