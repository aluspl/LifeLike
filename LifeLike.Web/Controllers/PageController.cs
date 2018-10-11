using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Repositories.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly IPageRepository _pageRepository;
        private readonly IEventLogRepository _logger;
        private readonly ILinkRepository _links;
        private readonly IMapper _mapper;

        public PageController(IPageRepository pageRepository, IEventLogRepository logger, ILinkRepository links, IMapper mapper)
        {
            _pageRepository = pageRepository;
            _logger = logger;
            _links = links;
            _mapper = mapper;
        }


        // GET
        [HttpGet("Posts")]
        public async Task<IActionResult> Posts()
        {
            await _logger.AddStat("Posts", "List", "Page");
            var list = await _pageRepository.List(PageCategory.Post);
            return Ok(list);
        }
        // GET

        [HttpGet("Pages")]
        public async Task<IActionResult> Pages()
        {
            try
            {
                await _logger.AddStat("All", "List", "Page");
                var isLogged = User.Identity.IsAuthenticated;

                var list = 
                  await _pageRepository.List(PageCategory.Page);
               
                return Ok(list);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }

        [HttpGet("Projects")]
        public async Task<IActionResult> Projects()
        {
            try
            {
                await _logger.AddStat("All", "List", "Projects");
                var isLogged = User.Identity.IsAuthenticated;

                var list = 
                    await _pageRepository.List(PageCategory.Projects);                
                return Ok(list);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                await _logger.AddStat(id, "Details", "Page");
                    
                var page = await _pageRepository.Get(id.ToLower());
                if (page == null) return NotFound();
                return Ok(page);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
//TODO: CATEGORY IN DROPDPOWN IN ANGULAR
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Page model)
        {
            try
            {
                await _logger.AddStat("Create", "Page");
                model.Published = DateTime.Now;
                if (model.Category == null) model.Category = "Post";
                model.ShortName = model?.ShortName?.ToLower();
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _pageRepository.Create(model, model.Link);
               
                return Ok(result);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] Page model)
        {
            try
            {
                await _logger.AddStat("Delete", "Page");

                if (model == null) return BadRequest();
                var result = await _pageRepository.Delete(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> Update(long id)
        {
            try
            {
                await _logger.AddStat("Update", "Page");
                var page = await _pageRepository.Get(id);
                return Ok(page);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromBody] Page model)
        {
            try
            {
                await _logger.AddStat("Update", "Page");
                
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var value = await _pageRepository.Update(model);
                return Ok(value);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return StatusCode(500);
            }
        }
    }
}