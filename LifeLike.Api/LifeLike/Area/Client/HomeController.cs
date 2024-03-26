using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Commons.Models.Config;
using LifeLike.Services.Commons.Models.Link;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Client;

[Area("client")]
[Route("[area]/[controller]")]
public class HomeController : BaseController
{
    private readonly IConfigService _config;
    private readonly ICategoryService _categoryService;
    private readonly ILogger _logger;
    private readonly ILinkService _link;

    public HomeController(
        IConfigService config,
        ICategoryService categoryService,
        ILogger logger,
        ILinkService link)
    {
        _link = link;
        _logger = logger;
        _config = config;
        _categoryService = categoryService;
    }

    [HttpGet("Menu")]
    [Return(typeof(ICollection<LinkModel>))]
    public async Task<IActionResult> GetMenuLinks()
    {
        var list = await _link.List(LinkCategory.Menu);
        return GetResult(list);
    }

    [HttpGet("Config")]
    [Return(typeof(ICollection<ConfigModel>))]
    public async Task<IActionResult> GetConfigs()
    {
        var list = await _config.List();
        return GetResult(list);
    }

    // GET
    [HttpGet("Categories")]
    [Return(typeof(ICollection<CategoryModel>))]
    public async Task<IActionResult> GetCategories()
    {
        var list = await _categoryService.List();
        return GetResult(list);
    }
}