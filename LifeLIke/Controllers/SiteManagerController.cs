using System;
using LifeLike.Models;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class SiteManagerController : Controller
    {
        private readonly IConfigRepository _config;

        public SiteManagerController(IConfigRepository configRepository)
        {
            _config = configRepository;
            
        }
        
        // GET
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
           var configs= _config.List();
            return View(configs);
        }
        public ActionResult Create()
        {
            var model=new Config();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Config model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _config.Create(model);
                    return RedirectToAction("List");
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
            var model = _config.Get(id);
            if (model == null) return RedirectToAction("List");
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Config model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _config.Update(model);
                    return RedirectToAction("List");
                }
            }
            catch (Exception dote)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }
 
            return View(model);
        }
        
        public ActionResult Delete(string id)
        {
            
            var model = _config.Get(id);
            if (model == null) return RedirectToAction("List");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Config model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _config.Delete(model);
                    return RedirectToAction("List");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Unable to Delete");
            }
 
            return View(model);
        }
    }
}