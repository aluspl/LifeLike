using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Page;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin;

[Area("admin")]
[Route("[area]/[controller]")]
public class PageController : BaseAuthController
{
    private readonly IPageService _pageService;

    public PageController(
        IPageService pagePageService)
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

    // GET
    [HttpGet("Category/{categoryId:guid}")]
    [Return(typeof(ICollection<PageModel>))]
    public async Task<IActionResult> Posts(Guid categoryId)
    {
        var list = await _pageService.ListByCategory(categoryId);
        return GetResult(list);
    }

    [HttpGet("Details/{shortName}")]
    [Return(typeof(PageModel))]
    public async Task<IActionResult> Details(string shortName)
    {
        var page = await _pageService.Get(shortName.ToLower());
        return GetResult(page);
    }

    [HttpPost]
    [Return(typeof(PageModel))]
    public async Task<IActionResult> Create([FromBody] CreatePageModel model)
    {
        var result = await _pageService.Create(model);
        return GetResult(result);
    }

    [HttpDelete("{id:guid}")]
    [ReturnEmpty]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _pageService.Delete(id);
        return GetResult();
    }

    [HttpPut("{id:guid}")]
    [Return(typeof(PageModel))]
    public async Task<IActionResult> Update([FromBody] CreatePageModel model, Guid id)
    {
        var result = await _pageService.Update(id, model);
        return GetResult(result);
    }
}