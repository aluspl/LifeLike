using System;
using LifeLike.Services;
using LifeLike.Services.ViewModel;
using LifeLike.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoService service;

        public VideoController(IVideoService repository)
        {
            service = repository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Video model)
        {
            model.PublishDate = DateTime.Now;
            if (!ModelState.IsValid)
                return BadRequest(Result.Failed);
            var item = service.Create(model);
            return Ok(item);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid) return BadRequest(Result.Failed);
            var item = service.Delete(id);
            return Ok(item);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Video item)
        {
            if (!ModelState.IsValid) return BadRequest(Result.Failed);
            var result = service.Update(item);
            return Ok(item);
        }
        // GET
        [HttpGet]
        public IActionResult Get()
        {
            var list = service.List();
            return Ok(list);
        }
    }
}