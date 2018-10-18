using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Services;
using LifeLike.Services.Extensions;
using LifeLike.Services.ViewModel;
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

        [HttpPost("Create")]
        public IActionResult Create(Video model)
        {
            model.PublishDate = DateTime.Now;

            if (!ModelState.IsValid) return BadRequest(Result.Failed);
            var item = service.Create(model);
            return Ok(item);

        }
        [HttpDelete("Delete")]
        public IActionResult Delete(long id)
        {
            if (!ModelState.IsValid) return BadRequest(Result.Failed);
            var item = service.Delete(id);
            return Ok(item);
        }
        // GET
        [HttpGet("List")]
        public IActionResult Get()
        {
            var list = service.List();
            return Ok(list);
        }
    }
}