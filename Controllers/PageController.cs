using System;
using LifeLike.Models;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using LifeLIke.Repositories;
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
        public ActionResult List()
        {
            _logger.AddStat("","List", "Page");

            var list=_pages.List();
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            _logger.AddStat(id,"Detail", "Page");

            var page = _pages.Get(id);
            if (page == null) return RedirectToAction("Index", "Home");
            return View(page);
        }
        [Authorize]
        public ActionResult Create()
        {
            _logger.AddStat("","Create", "Page");

            var model=new PageViewModel();
            return View(model);

        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _links.Create(model.Link);
                    _pages.Create(PageViewModel.DataModel(model));
                    return RedirectToAction("Index","Home");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }
 
            return View(model);

        }
        public ActionResult Delete(long id)
        {
            var page = _pages.Get(id);
            

            return View(PageViewModel.ViewModel(page));

        }
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PageViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var datamodel = _pages.Get(model.Id);
                    var link = _links.Get(model.ShortName);
                    var result=_pages.Delete(datamodel, link);
                    
                    if (result==Result.Success) return RedirectToAction("Index","Home");
                                   
               }
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);

                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }
 
            return View(model);

        }
        [Authorize]
        public ActionResult Update(long id)
        {
            try
            {
                var page = _pages.Get(id);               
                return View(PageViewModel.ViewModel(page));

            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);
            }

            return RedirectToAction("List", "Page");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var result=_pages.Update(PageViewModel.DataModel(model));
                    
                    if (result==Result.Success) return RedirectToAction("Index","Home");
                }
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);

                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }
 
            return View(model);

        }

    }
    
}