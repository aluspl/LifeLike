using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Models.Link;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Link;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LifeLike.Area.Admin
{
    [Area("admin")]
    [Route("[area]/[controller]")]
    public class LinkController : BaseController
    {
        private readonly ILinkService _linkService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public LinkController(ILinkService repository, ILogger logger, IMapper mapper)
        {
            _linkService = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        [Return(typeof(ICollection<LinkResponseModel>))]
        public IActionResult GetList()
        {
            var list = _linkService.List();
            var response = _mapper.Map<ICollection<LinkResponseModel>>(list);
            return GetResult(response);
        }

        [HttpPost]
        [Return(typeof(LinkResponseModel))]
        public IActionResult Create(LinkRequestModel model)
        {
            var writeModel = _mapper.Map<LinkWriteModel>(model);
            var result = _linkService.Create(writeModel);
            var response = _mapper.Map<LinkResponseModel>(result);
            return GetResult(response);
        }

        [HttpPut("{id:guid}")]
        [Return(typeof(LinkResponseModel))]
        public async Task<IActionResult> Update(Guid id, [FromBody] LinkRequestModel model)
        {
            var writeModel = _mapper.Map<LinkWriteModel>(model);
            var result = await _linkService.Update(id, writeModel);
            var response = _mapper.Map<LinkResponseModel>(result);
            return GetResult(response);
        }

        [HttpDelete("{id:guid}")]
        [ReturnEmpty()]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _linkService.Delete(id);
            return GetResult();
        }
    }
}
