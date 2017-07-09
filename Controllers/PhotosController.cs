
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using LifeLIke.Repositories;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace LifeLIke.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IEventLogRepository logger;
        private readonly IPhotoRepository _photoRepository;
        private readonly IGalleryRepository _gallery;


        public PhotosController(IEventLogRepository logger,
            IPhotoRepository photoRepository,
            IGalleryRepository gallery)
        {
            logger = logger;
            _photoRepository = photoRepository;
            _gallery = gallery;

        }
        [Authorize]
        public IActionResult CreateGallery()
        {
            return View(new GalleryViewModel());
        }
        [HttpPost]
        public IActionResult CreateGallery(GalleryViewModel model)
        {
            try
            {
                model.Created=DateTime.Now;
                model.ShortTitle=model.ShortTitle.Trim().Replace(" ","");
                var gallery = GalleryViewModel.Get(model);
                _gallery.Create(gallery);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                logger.AddExceptionLog(e);
            }
            return View(new GalleryViewModel());
        }
        // GET
        public ActionResult Index()
        {
            return View( _gallery.List().Select(GalleryViewModel.Get));
        }
        // GET
        public ActionResult Detail(string id)
        {
            try
            {
                var selectedgallery = _gallery.Get(id);
                return View(GalleryViewModel.Get(selectedgallery));

            }
            catch (Exception e)
            {
                logger.AddExceptionLog(e);
                throw;
            }
        }

        public IActionResult GalleryManager()
        {
           return View( _gallery.List().Select(GalleryViewModel.Get));
        }
        
        [Authorize]
        public IActionResult Delete(long id)
        {
            var gallery=_gallery.Get(id);

            return View(GalleryViewModel.Get(gallery));
        }
        [HttpPost]
        public IActionResult Delete(GalleryViewModel model)
        {
            try
            {
                _gallery.Delete(GalleryViewModel.Get(model));
            }
            catch (Exception e)
            {
               logger.AddExceptionLog(e);
            }
            return View(model);
        }
        [Authorize]
        public IActionResult Update(long id)
        {
            var gallery=_gallery.Get(id);

            return View(GalleryViewModel.Get(gallery));
        }
        [HttpPost]
        public IActionResult Update(GalleryViewModel model)
        {
            try
            {
                _gallery.Delete(GalleryViewModel.Get(model));
            }
            catch (Exception e)
            {
                logger.AddExceptionLog(e);
            }
            return View(model);
        }
    }
}