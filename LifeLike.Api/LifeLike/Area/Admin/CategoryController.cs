using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Models.Category;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin
{
    [Area("admin")]
    [Route("[area]/[controller]")]
    public class CategoryController : BaseAuthController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryService categoryServiceRepository,
            IMapper mapper)
        {
            _categoryService = categoryServiceRepository;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        [Return(typeof(ICollection<CategoryResponseModel>))]
        public async Task<IActionResult> All()
        {
            var list = await _categoryService.List();
            var response = _mapper.Map<ICollection<CategoryResponseModel>>(list);
            return GetResult(response);
        }

        [HttpGet("{id:guid}")]
        [Return(typeof(CategoryResponseModel))]
        public async Task<IActionResult> Details(Guid id)
        {
            var page = await _categoryService.Get(id);
            var response = _mapper.Map<CategoryResponseModel>(page);
            return GetResult(response);
        }

        [HttpPost]
        [Return(typeof(CategoryResponseModel))]
        public async Task<IActionResult> Create(CategoryRequestModel model)
        {
            var service = _mapper.Map<CategoryWriteModel>(model);
            var result = await _categoryService.Create(service);
            var response = _mapper.Map<CategoryResponseModel>(result);
            return GetResult(response);
        }

        [HttpPut("{id:guid}")]
        [Return(typeof(CategoryResponseModel))]
        public async Task<IActionResult> Update(CategoryRequestModel model, Guid id)
        {
            var service = _mapper.Map<CategoryWriteModel>(model);
            var result = await _categoryService.Update(id, service);
            var response = _mapper.Map<CategoryResponseModel>(result);
            return GetResult(response);
        }

        [HttpDelete("{id:guid}")]
        [ReturnEmpty]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Delete(id);
            return GetResult();
        }
    }
}
