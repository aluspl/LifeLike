using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly IPageRepository _pages;
        private readonly IEventLogRepository _logger;
        private readonly ILinkRepository _links;

        public PageController(IPageRepository pageRepository, IEventLogRepository logger, ILinkRepository links)
        {
            _pages = pageRepository;
            _logger = logger;
            _links = links;
        }

   
        // GET
        [HttpGet("Posts")]
        public async Task<IActionResult> Posts()
        {
            await  _logger.AddStat("", "List", "Page");
            var list = await _pages.List();
            return Json(list.Where(p=>p.Category==PageCategory.Page).Select(PageViewModel.ViewModel));
        }
        // GET
        [HttpGet("Pages")]
        public async Task<IActionResult> Pages()
        {
            await  _logger.AddStat("", "List", "Page");
            var list = await _pages.List();
            return Json(list.Where(p=>p.Category==PageCategory.Post).Select(PageViewModel.ViewModel));
        }       
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                await  _logger.AddStat(id, "Details", "Page");

                var page =await _pages.Get(id);
                if (page==null) return Json(null);
                return Json(PageViewModel.ViewModel(page));

            }
            catch(Exception e)
            {
                await  _logger.AddException(e);
                return null;
            }
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Create(PageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await   _links.Create(model.Link);
                    return await _pages.Create(PageViewModel.DataModel(model));
                }
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
            }

            return Result.Failed;

        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Delete(PageViewModel model)
        {
            try
            {
                if (model == null) return Result.Failed;
                var datamodel =await _pages.Get(model.Id);
                var link =await _links.Get(model.ShortName);
                return await _pages.Delete(datamodel, link);

            }
            catch (Exception e)
            {
               await _logger.AddException(e);
                return Result.Failed;
            }

        }
        [Authorize]
        public async Task<PageViewModel> Update(long id)
        {
            try
            {
                var page =await _pages.Get(id);
                return PageViewModel.ViewModel(page);
            }
            catch (Exception e)
            {
              await  _logger.AddException(e);
                return null;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Result> Update(PageViewModel model)
        {
            try
            {
                return ModelState.IsValid
                    ? await _pages.Update(PageViewModel.DataModel(model))
                    :  Result.Failed;
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
          
                return Result.Failed;
            }


        }

    }

}