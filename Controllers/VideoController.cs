using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
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

        [Authorize]
        public ActionResult Create()
        {
            var model=new LinkViewModel
            {
               Category = LinkCategory.Video, IconName = "film"
            };
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
               await _logger.AddExceptionLog(e);
            }
 
            return View(model);

        }
        // GET
        public async Task<ActionResult> Index()
        {
            var list=await _repository.List(LinkCategory.Video);
            var items= list.Select(LinkViewModel.Get);
            return    View(items);
        }
    }
}