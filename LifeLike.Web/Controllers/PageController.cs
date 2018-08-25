using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Web.Extensions;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly IPageRepository _pages;
        private readonly IEventLogRepository _logger;
        private readonly ILinkRepository _links;
        private readonly IMapper _mapper;

        public PageController(IPageRepository pageRepository, IEventLogRepository logger, ILinkRepository links, IMapper mapper)
        {
            _pages = pageRepository;
            _logger = logger;
            _links = links;
            _mapper = mapper;
        }


        // GET
        [HttpGet("Posts")]
        public async Task<IActionResult> Posts()
        {
            await _logger.AddStat("Posts", "List", "Page");
            var list = await _pages.List();
            var posts = list.Where(p => p.Category == PageCategory.Post).Select(_mapper.Map<PageViewModel>);
            return Ok(posts);
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
                // isLogged ? 
                    await _pages.List();
                    // await _pages.List(PageCategory.App | PageCategory.Game);
                var pageList = list
                    .Where(p => p.Category == PageCategory.Page)
                    .Select(_mapper.Map<PageViewModel>);
                return Ok(pageList);
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
                    
                var page = await _pages.Get(id.ToLower());
                if (page == null) return NotFound();
                var dto = _mapper.Map<PageViewModel>(page);

                return Ok(dto);
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
        public async Task<IActionResult> Create([FromBody] PageViewModel model)
        {
            try
            {
                await _logger.AddStat("Create", "Page");
                model.Published = DateTime.Now;
                if (model.Category == null) model.Category = "Post";
                model.ShortName = model?.ShortName?.ToLower();
                if (!ModelState.IsValid) return BadRequest(ModelState);
//                var  dto=  PageViewModel.DataModel(model);
                var dto = _mapper.Map<Page>(model);
                var result = await _pages.Create(dto, model.Link);
               
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
        public async Task<IActionResult> Delete([FromBody] PageViewModel model)
        {
            try
            {
                await _logger.AddStat("Delete", "Page");

                if (model == null) return BadRequest();
                var datamodel = await _pages.Get(model.ShortName);
                var link = await _links.Get(model.ShortName);
                var result = await _pages.Delete(datamodel, link);
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
                var page = await _pages.Get(id);
                return Ok(_mapper.Map<PageViewModel>(page));
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromBody] PageViewModel model)
        {
            try
            {
                await _logger.AddStat("Update", "Page");
                
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var dto = _mapper.Map<Page>(model);
                var value = await _pages.Update(dto);
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