using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
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
        public async Task<IEnumerable<LinkViewModel>> GetList()
        {
            try
            {
                var list = await _repository.List();            
                return  list.Select(LinkViewModel.Get);
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
                return null;
            }
       
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Create(LinkViewModel model)
        {
            try
            {
                return ModelState.IsValid
                    ? await _repository.Create(LinkViewModel.Get(model))
                    : Result.Failed;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
 

        }
        [Authorize]
        public async Task<LinkViewModel> Update(long id)
        {
            var model =await _repository.Get(id);
            return LinkViewModel.Get(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Update(LinkViewModel model)
        {
            try
            {
                return ModelState.IsValid
                    ? await _repository.Update(LinkViewModel.Get(model))
                    : Result.Failed;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            } 
        }
       
        [HttpPost]
        public async Task<Result> Delete(LinkViewModel model)
        {
            try
            {
                return ModelState.IsValid
                    ? await _repository.Delete(LinkViewModel.Get(model))
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