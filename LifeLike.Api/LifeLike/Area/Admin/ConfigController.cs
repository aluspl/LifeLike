using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Models.Config;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Config;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin
{
    [Area("admin")]
    [Route("[area]/[controller]")]
    public class ConfigController : BaseAuthController
    {
        private readonly IConfigService _configService;
        private readonly IMapper _mapper;

        public ConfigController(
            IConfigService configServiceService,
            IMapper mapper)
        {
            _configService = configServiceService;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        [Return(typeof(ICollection<ConfigResponseModel>))]
        public async Task<IActionResult> All()
        {
            var list = await _configService.List();
            var response = _mapper.Map<ICollection<ConfigResponseModel>>(list);
            return GetResult(response);
        }

        [HttpGet("{id:guid}")]
        [Return(typeof(ConfigResponseModel))]
        public async Task<IActionResult> Details(Guid id)
        {
            var page = await _configService.Get(id);
            var response = _mapper.Map<ConfigResponseModel>(page);
            return GetResult(response);
        }

        [HttpPost]
        [Return(typeof(ConfigResponseModel))]
        public async Task<IActionResult> Create(ConfigRequestModel model)
        {
            var service = _mapper.Map<ConfigWriteModel>(model);
            var result = await _configService.Create(service);
            var response = _mapper.Map<ConfigResponseModel>(result);
            return GetResult(response);
        }

        [HttpPut]
        [Return(typeof(ConfigResponseModel))]
        public async Task<IActionResult> Update(ConfigRequestModel model)
        {
            var service = _mapper.Map<ConfigWriteModel>(model);
            var result = await _configService.Update(service);
            var response = _mapper.Map<ConfigResponseModel>(result);
            return GetResult(response);
        }

        [HttpDelete("{id:guid}")]
        [ReturnEmpty]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _configService.Delete(id);
            return GetResult();
        }
    }
}
