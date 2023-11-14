using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin;

[Area("admin")]
[Route("[area]/[controller]")]
public class CategoryController : BaseAuthController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(
        ICategoryService categoryServiceRepository)
    {
        _categoryService = categoryServiceRepository;
    }

    // GET
    [HttpGet]
    [Return(typeof(ICollection<CategoryModel>))]
    public async Task<IActionResult> All()
    {
        var result = await _categoryService.List();
        return GetResult(result);
    }

    [HttpGet("{id:guid}")]
    [Return(typeof(CategoryModel))]
    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _categoryService.Get(id);
        return GetResult(result);
    }

    [HttpPost]
    [Return(typeof(CategoryModel))]
    public async Task<IActionResult> Create(CategoryWriteModel model)
    {
        var result = await _categoryService.Create(model);
        return GetResult(result);
    }

    [HttpPut("{id:guid}")]
    [Return(typeof(CategoryModel))]
    public async Task<IActionResult> Update(CategoryWriteModel model, Guid id)
    {
        var result = await _categoryService.Update(id, model);
        return GetResult(result);
    }

    [HttpDelete("{id:guid}")]
    [ReturnEmpty]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.Delete(id);
        return GetResult();
    }
}