using System;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class PageController : Controller
    {
        private IPageRepository _pages;

        public PageController(IPageRepository pageRepository)
        {
            _pages = pageRepository;
        }
        // GET
        public ActionResult List()
        {
            var list=_pages.List();
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            var page = _pages.Get(id);
            if (page == null) return RedirectToAction("Index", "Home");
            return View(page);
        }
        public ActionResult Create()
        {
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
                    _pages.Create(model.DataModel,model.Link);
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
        public ActionResult Delete(string id)
        {
            var page = _pages.Get(id).ViewModel;

            return View(page);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pages.Delete(model.DataModel);
                    
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
        public ActionResult Update(string id)
        {
            var page = _pages.Get(id).ViewModel;

            return View(page);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pages.Delete(model.DataModel);
                    
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

    }
    
}