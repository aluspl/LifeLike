using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Link;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin;

[Area("admin")]
[Route("[area]/[controller]")]
public class LinkController : BaseController
{
    private readonly ILinkService _linkService;
    private readonly ILogger _logger;

    public LinkController(ILinkService repository, ILogger logger)
    {
        _linkService = repository;
        _logger = logger;
    }

    // GET
    [HttpGet]
    [Return(typeof(ICollection<LinkModel>))]
    public IActionResult GetList()
    {
        var list = _linkService.List();
        return GetResult(list);
    }

    [HttpPost]
    [Return(typeof(LinkModel))]
    public IActionResult Create(CreateLinkModel model)
    {
        var result = _linkService.Create(model);
        return GetResult(result);
    }

    [HttpPut("{id:guid}")]
    [Return(typeof(LinkModel))]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateLinkModel model)
    {
        var result = await _linkService.Update(id, model);
        return GetResult(result);
    }

    [HttpDelete("{id:guid}")]
    [ReturnEmpty()]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _linkService.Delete(id);
        return GetResult();
    }
}