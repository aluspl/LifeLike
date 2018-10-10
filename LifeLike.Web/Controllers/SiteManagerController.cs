using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    
    [Route("api/[controller]")]
    public class SiteManagerController : Controller
    {
        private readonly IConfigRepository _config;

        private readonly IEventLogRepository _logger;

        public SiteManagerController(IConfigRepository configRepository, IEventLogRepository logger)
        {
            _config = configRepository;
            _logger = logger;
        }

        // GET
        [Authorize]
        public async Task<IEnumerable<ConfigEntity>> GetList()
        {
            var configs = await _config.List();
            return configs;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Create(ConfigEntity model)
        {
            try
            {
                return ModelState.IsValid ? await _config.Create(model) : Result.Failed;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }

        [Authorize]
        public async Task<ConfigEntity> Update(string id)
        {
            var model = await _config.Get(id);
            return model;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Update(ConfigEntity model)
        {
            try
            {
                return ModelState.IsValid ? await _config.Update(model) :  Result.Failed;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }
    }
}