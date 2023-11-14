using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Page;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Client;

[Area("client")]
[Route("[area]/[controller]")]
public class PageController : BaseController
{
    private readonly IQueryPageService _pageService;

    public PageController(
        IQueryPageService pagePageService)
    {
        _pageService = pagePageService;
    }

    // GET
    [HttpGet("All")]
    [Return(typeof(ICollection<PageModel>))]
    public async Task<IActionResult> All()
    {
        var list = await _pageService.List();
        return GetResult(list);
    }

    [HttpGet("Details/{shortName}")]
    [Return(typeof(PageModel))]
    public async Task<IActionResult> Details(string shortName)
    {
        var page = await _pageService.Get(shortName.ToLower());
        return GetResult(page);
    }
}