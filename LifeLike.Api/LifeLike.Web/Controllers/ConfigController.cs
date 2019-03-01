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
    public class ConfigController : Controller
    {
        private readonly IConfigService _config;

        public ConfigController(IConfigService configRepository)
        {
            _config = configRepository;
        }
         
        [HttpPost]
        public IActionResult Create(Config model)
        {
            if (!ModelState.IsValid) return BadRequest();
            _config.Create(model);
            return Ok();
        }
       
        [HttpPut]
        public IActionResult Update(Config model)
        {
            if (!ModelState.IsValid) return BadRequest();
            _config.Update(model);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Config model)
        {
            if (!ModelState.IsValid) return BadRequest();
            _config.Update(model);
            return Ok();
        }
    }
}