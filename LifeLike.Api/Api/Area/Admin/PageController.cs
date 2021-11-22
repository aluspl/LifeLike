using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.Page;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Page;
using Microsoft.AspNetCore.Mvc;

namespace Api.Area.Admin
{
    [Area("admin")]
    [Route("[area]/[controller]")]
    public class PageController : BaseAuthController
    {
        private readonly IPageService _pageService;
        private readonly IMapper _mapper;

        public PageController(
            IPageService pagePageService,
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

        // GET
        [HttpGet("Category/{categoryId:guid}")]
        [Return(typeof(ICollection<PageResponseModel>))]
        public async Task<IActionResult> Posts(Guid categoryId)
        {
            var list = await _pageService.ListByCategory(categoryId);
            var response = _mapper.Map<ICollection<PageReadModel>>(list);
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

        [HttpPost]
        [Return(typeof(PageResponseModel))]
        public IActionResult Create([FromBody] PageRequestModel model)
        {
            var writeModel = _mapper.Map<PageWriteModel>(model);
            writeModel.Published = DateTime.Now;
            writeModel.ShortName = model?.ShortName?.ToLower();
            var result = _pageService.Create(writeModel);
            var response = _mapper.Map<PageResponseModel>(result);
            return GetResult(response);
        }

        [HttpDelete("{id:guid}")]
        [ReturnEmpty]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _pageService.Delete(id);
            return GetResult();
        }

        [HttpPut("{id:guid}")]
        [Return(typeof(PageResponseModel))]
        public async Task<IActionResult> Update([FromBody] PageRequestModel model, Guid id)
        {
            var writeModel = _mapper.Map<PageWriteModel>(model);
            var value = await _pageService.Update(id, writeModel);
            var response = _mapper.Map<PageResponseModel>(value);
            return GetResult(response);
        }
    }
}
