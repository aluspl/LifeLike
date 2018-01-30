using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly ILinkRepository _repository;
        private readonly IEventLogRepository _logger;

        public VideoController(ILinkRepository repository, IEventLogRepository logger)
        {
            _repository = repository;
            _logger=logger;
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Create(LinkViewModel model)
        {
            try
            {
                model.Category = LinkCategory.Video;
                model.IconName = "film";
                if (ModelState.IsValid)
                {
                  return  await _repository.Create(LinkViewModel.Get(model));                  
                }
                else
                {
                    return Result.Failed;
                }
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
               return Result.Failed;
            }
 
        }
        // GET
        public async Task<IEnumerable<LinkViewModel>> GetList()
        {
            var list=await _repository.List(LinkCategory.Video);
            var items= list.Select(LinkViewModel.Get);
            return  items;
        }
    }
}