using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Video;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin;

[Area("admin")]
[Route("[area]/[controller]")]
public class ContentController : BaseAuthController
{
    private readonly IContentService _contentService;

    public ContentController(IContentService repository)
    {
        _contentService = repository;
    }

    [HttpPost]
    [Return(typeof(ContentModel))]
    public async Task<IActionResult> Create(ContentWriteModel model)
    {
        var item = await _contentService.Create(model);
        return GetResult(item);
    }

    [HttpDelete("{id:guid}")]
    [ReturnEmpty()]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _contentService.Delete(id);
        return GetResult();
    }

    // GET
    [HttpGet("List")]
    [Return(typeof(ICollection<ContentModel>))]
    public async Task<IActionResult> Get()
    {
        var list = await _contentService.List();
        return GetResult(list);
    }
}