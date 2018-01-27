using System;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
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
        public async Task<ActionResult> List()
        {
            await  _logger.AddStat("", "List", "Page");

            var list = await _pages.List();
            return View(list);
        }

        public async Task<ActionResult> Detail(string id)
        {
            await  _logger.AddStat(id, "Detail", "Page");

            var page =await _pages.Get(id);
            if (page == null) return RedirectToAction("Index", "Home");
            return View(page);
        }
        [Authorize]
        public async Task<ActionResult> Create()
        {
            await _logger.AddStat("", "Create", "Page");

            var model = new PageViewModel();
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await   _links.Create(model.Link);
                    await  _pages.Create(PageViewModel.DataModel(model));
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
            }
           
            return View(model);

        }
        public async Task<ActionResult> Delete(long id)
        {
            var page = await _pages.Get(id);
            return View(PageViewModel.ViewModel(page));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(PageViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var datamodel =await _pages.Get(model.Id);
                    var link =await _links.Get(model.ShortName);
                    var result =await _pages.Delete(datamodel, link);

                    if (result == Result.Success) return RedirectToAction("Index", "Home");

                }
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
              
            }

            return View(model);

        }
        [Authorize]
        public async Task<ActionResult> Update(long id)
        {
            try
            {
                var page =await _pages.Get(id);
                return View(PageViewModel.ViewModel(page));

            }
            catch (Exception e)
            {
              await  _logger.AddException(e);
            }

            return RedirectToAction("List", "Page");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _pages.Update(PageViewModel.DataModel(model));

                    if (result == Result.Success) return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
               await _logger.AddException(e);

                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }

            return View(model);

        }

    }

}