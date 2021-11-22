using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.Category;
using Api.Models.Config;
using Api.Models.Link;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Area.Client
{
    [Area("client")]
    [Route("[area]/[controller]")]
    public class HomeController : BaseController
    {
        private readonly IConfigService _config;
        private readonly ICategoryService _categoryService;
        private readonly ILogger _logger;
        private readonly ILinkService _link;
        private readonly IMapper _mapper;

        public HomeController(
            IConfigService config,
            ICategoryService categoryService,
            ILogger logger,
            ILinkService link,
            IMapper mapper)
        {
            _link = link;
            _mapper = mapper;
            _logger = logger;
            _config = config;
            _categoryService = categoryService;
        }

        [HttpGet("Menu")]
        [Return(typeof(ICollection<LinkResponseModel>))]
        public async Task<IActionResult> GetMenuLinks()
        {
            var list = await _link.List(LinkCategory.Menu);
            var response = _mapper.Map<ICollection<LinkResponseModel>>(list);
            return GetResult(response);
        }

        [HttpGet("Config")]
        [Return(typeof(ICollection<ConfigResponseModel>))]
        public async Task<IActionResult> GetConfigs()
        {
            var configs = await _config.List();
            var response = _mapper.Map<ICollection<ConfigResponseModel>>(configs);
            return GetResult(response);
        }

        // GET
        [HttpGet("Categories")]
        [Return(typeof(ICollection<CategoryResponseModel>))]
        public async Task<IActionResult> GetCategories()
        {
            var list = await _categoryService.List();
            var response = _mapper.Map<ICollection<CategoryResponseModel>>(list);
            return GetResult(response);
        }
    }
}
