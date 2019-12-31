using LifeLike.Services;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{

    [Route("api/[controller]")]
    public class ConfigController : BaseController
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