using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Repositories.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class LinkManagerController : Controller
    {
        private readonly ILinkRepository _repository;
        private readonly IEventLogRepository _logger;

        public LinkManagerController(ILinkRepository repository, IEventLogRepository logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var list = await _repository.List();            
                return  Ok(list);
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
                return  BadRequest(e);
            }
       
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Link model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _repository.Create(model));
                }
              return BadRequest();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
              return BadRequest(e);
            }
 

        }
        [HttpGet("Update")]
        [Authorize]
        public async Task<IActionResult> Update(long id)
        {
            var model =await _repository.Get(id);
            return Ok(model);

        }
        [HttpPut("Update")]
        [ValidateAntiForgeryToken]
        public async Task<Result> Update([FromBody]Link model)
        {
            try
            {
                return ModelState.IsValid
                    ? await _repository.Update(model)
                    : Result.Failed;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            } 
        }
       
        [HttpDelete("Delete")]
        public async Task<Result> Delete([FromBody]Link model)
        {
            try
            {
                return ModelState.IsValid
                    ? await _repository.Delete(model)
                    : Result.Failed;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }
        
    }
}