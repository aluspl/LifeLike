using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Config;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin;

[Area("admin")]
[Route("[area]/[controller]")]
public class ConfigController : BaseAuthController
{
    private readonly IConfigService _configService;

    public ConfigController(
        IConfigService configServiceService)
    {
        _configService = configServiceService;
    }

    // GET
    [HttpGet]
    [Return(typeof(ICollection<ConfigModel>))]
    public async Task<IActionResult> All()
    {
        var list = await _configService.List();
        return GetResult(list);
    }

    [HttpGet("{id:guid}")]
    [Return(typeof(ConfigModel))]
    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _configService.Get(id);
        return GetResult(result);
    }

    [HttpPost]
    [Return(typeof(ConfigModel))]
    public async Task<IActionResult> Create(CreateConfigModel model)
    {
        var result = await _configService.Create(model);
        return GetResult(result);
    }

    [HttpPut("{id:guid}")]
    [Return(typeof(ConfigModel))]
    public async Task<IActionResult> Update(Guid id, UpdateConfigModel model)
    {
        var result = await _configService.Update(id, model);
        return GetResult(result);
    }

    [HttpDelete("{id:guid}")]
    [ReturnEmpty]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _configService.Delete(id);
        return GetResult();
    }
}