using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Web.Extensions;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoRepository _repository;
        private readonly IEventLogRepository _logger;
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository repository, IEventLogRepository logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(VideoViewModel model)
        {
            try
            {
                model.PublishDate = DateTime.Now;

                if (!ModelState.IsValid) return BadRequest(Result.Failed);
                var item = await _repository.Create(_mapper.Map<Video>(model));
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
                var items = list.Select(_mapper.Map);
                Debug.WriteLine(items.ToJSON());
                return Ok(items);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
    }
}