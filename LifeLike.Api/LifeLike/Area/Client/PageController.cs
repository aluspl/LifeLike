using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Models.Page;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Page;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Client
{
    [Area("client")]
    [Route("[area]/[controller]")]
    public class PageController : BaseController
    {
        private readonly IQueryPageService _pageService;
        private readonly IMapper _mapper;

        public PageController(
            IQueryPageService pagePageService,
            IMapper mapper)
        {
            _pageService = pagePageService;
            _mapper = mapper;
        }

        // GET
        [HttpGet("All")]
        [Return(typeof(ICollection<PageResponseModel>))]
        public async Task<IActionResult> All()
        {
            var list = await _pageService.List();
            var response = _mapper.Map<ICollection<PageResponseModel>>(list);
            return GetResult(response);
        }

        [HttpGet("Details/{shortName}")]
        [Return(typeof(PageResponseModel))]
        public async Task<IActionResult> Details(string shortName)
        {
            var page = await _pageService.Get(shortName.ToLower());
            var response = _mapper.Map<PageResponseModel>(page);
            return GetResult(response);
        }
    }
}
