using System;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class LinkManagerController : Controller
    {
        private readonly ILinkRepository _repository;

        public LinkManagerController(ILinkRepository repository)
        {
            _repository = repository;
        }
        // GET
        public ActionResult Index()
        {
            var list = _repository.List().Select(LinkViewModel.Get);
            return    View(list);
        }
        
        
        
        public ActionResult Create()
        {
         var model=new LinkViewModel();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LinkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Create(LinkViewModel.Get(model));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }
 
            return View(model);

        }
        
        public ActionResult Update(long id)
        {
            var model = _repository.Get(id);
            if (model == null) return RedirectToAction("Index");
            return View(LinkViewModel.Get(model));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(LinkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(LinkViewModel.Get(model));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }
 
            return View(model);
        }
        
        public ActionResult Delete(long id)
        {
            
            var model = _repository.Get(id);
            if (model == null) return RedirectToAction("Index");
            return View(LinkViewModel.Get(model));
        }
        [HttpPost]
        public ActionResult Delete(LinkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Delete(LinkViewModel.Get(model));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to Delete");
            }
 
            return View(model);
        }
        
    }
}