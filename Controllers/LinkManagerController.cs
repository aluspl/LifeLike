using System;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IEventLogRepository _logger;

        public LinkManagerController(ILinkRepository repository, IEventLogRepository logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var list = await _repository.List();
            
            return    View(list.Select(LinkViewModel.Get));
        }
        
        
        [Authorize]
        public ActionResult Create()
        {
            var model=new LinkViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LinkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.Create(LinkViewModel.Get(model));
                    return RedirectToAction("Index");
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
            var model =await _repository.Get(id);
            if (model == null) return RedirectToAction("Index");
            return View(LinkViewModel.Get(model));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(LinkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.Update(LinkViewModel.Get(model));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
            }
 
            return View(model);
        }
        
        [Authorize]
        public async Task<ActionResult> Delete(long id)
        {
            
            var model = await _repository.Get(id);
            if (model == null) return RedirectToAction("Index");
            return View(LinkViewModel.Get(model));
        }
        [HttpPost]
        public async Task<ActionResult> Delete(LinkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   await _repository.Delete(LinkViewModel.Get(model));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
            }
 
            return View(model);
        }
        
    }
}