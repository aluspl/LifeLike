using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class VideoController : Controller
    {
        private readonly ILinkRepository _repository;

        public VideoController(ILinkRepository repository)
        {
            _repository = repository;
        }
        public IActionResult GalleryManager()
        {
            return View( );
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
        // GET
        public ActionResult Index()
        {
           var items= _repository.List(LinkCategory.Video).Select(LinkViewModel.Get);
//            var items = new List<LinkViewModel>
//            {
//                new LinkViewModel {Link="https://www.youtube.com/watch?v=SC4o9JqI_aA", Name = "VLOG 4 : Żywiec"},
//                new LinkViewModel {Link = "https://www.youtube.com/watch?v=kHMqiPbrKx8", Name = "VLOG 3 : W Aucie"},
//
//                new LinkViewModel {Link = "https://www.youtube.com/watch?v=Qi5tp0eZHt8", Name = "VLOG 2 : Podsumowanie DSP 2017"},
//
//                new LinkViewModel {Link = "1Gjnnq93X9E", Name = "VLOG 1 : DSP 2017"},
//                new LinkViewModel {Link = "Q8v0KHMtwBs", Name = "Kawowe Podróże: Islandia"},
//                new LinkViewModel {Link = "QnL0mgOAYfQ", Name = "Kawowe Podróże: Grecja"},
//
//            };
            return    View(items);
        }
    }
}