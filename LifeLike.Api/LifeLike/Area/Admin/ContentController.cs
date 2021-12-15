using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Models.Content;
using LifeLike.Services.Commons.Interfaces.Page;
using LifeLike.Services.Commons.Models.Video;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin
{
    [Area("admin")]
    [Route("[area]/[controller]")]
    public class ContentController : BaseAuthController
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentController(IContentService repository,
            IMapper mapper)
        {
            _contentService = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Return(typeof(ContentResponseModel))]
        public async Task<IActionResult> Create(ContentRequestModel model)
        {
            var request = _mapper.Map<ContentWriteModel>(model);
            var item = await _contentService.Create(request);
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
        [Return(typeof(ICollection<ContentResponseModel>))]
        public async Task<IActionResult> Get()
        {
            var list = await _contentService.List();
            return GetResult(list);
        }
    }
}
