using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Services;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly IPageService service;
        private readonly ILinkService _links;
        private readonly IMapper _mapper;

        public PageController(IPageService pageRepository, ILinkService links, IMapper mapper)
        {
            service = pageRepository;
            _links = links;
            _mapper = mapper;
        }


        // GET
        [HttpGet("Posts")]
        public IActionResult Posts()
        {
            var list = service.List(PageCategory.Post);
            return Ok(list);
        }
        // GET

        [HttpGet("Pages")]
        public IActionResult Pages()
        {
                var isLogged = User.Identity.IsAuthenticated;

                var list =
                   service.List(PageCategory.Page);

                return Ok(list);
        }

        [HttpGet("Projects")]
        public IActionResult Projects()
        {
                var isLogged = User.Identity.IsAuthenticated;

                var list =
                     service.List(PageCategory.Projects);
                return Ok(list);
            
        }
        [HttpGet("Details/{id}")]
        public IActionResult Details(string id)
        {
                var page = service.Get(id.ToLower());
                if (page == null) return NotFound();
                return Ok(page);            
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Page model)
        {
                model.Published = DateTime.Now;
                model.ShortName = model?.ShortName?.ToLower();
                if (model.Category == null) model.Category = "Post";
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var result = service.Create(model, model.Link);

                return Ok(result);        
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Page model)
        {
                if (model == null) return BadRequest();
                var result = service.Delete(model);
                return Ok(result);
        }
        [HttpGet("Update")]
        public IActionResult Update(string id)
        {
            var page = service.Get(id);
            return Ok(page);
        }

        [HttpPut("Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromBody] Page model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var value = service.Update(model);
            return Ok(value);
        }
    }
}