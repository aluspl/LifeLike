using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Services.Extensions;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoRepository _repository;
        private readonly ILogService _logger;
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository repository, ILogService logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Video model)
        {
            try
            {
                model.PublishDate = DateTime.Now;

                if (!ModelState.IsValid) return BadRequest(Result.Failed);
                var item = await _repository.Create(model);
                return Ok(item);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
         [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(Result.Failed);
                var item = await _repository.Delete(new Video { Id = id});
                return Ok(item);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
        // GET
        [HttpGet("List")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _repository.List();
                return Ok(list);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
    }
}