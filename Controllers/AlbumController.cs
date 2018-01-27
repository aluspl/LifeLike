
using System;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IEventLogRepository _logger;
        private readonly IPhotoRepository _photoRepository;
        private readonly IGalleryRepository _gallery;
        private readonly IHostingEnvironment _hosting;


        public AlbumController(IEventLogRepository logger,
            IPhotoRepository photoRepository,
            IGalleryRepository gallery,
            IHostingEnvironment hosting)
        {
            _hosting = hosting;
            _logger = logger;
            _photoRepository = photoRepository;
            _gallery = gallery;

        }
        [Authorize]
        public IActionResult CreateGallery()
        {
            return View(new GalleryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateGallery(GalleryViewModel model)
        {
           await _logger?.AddStat(model.ShortTitle,"Create", "Album");

            try
            {
                model.Created=DateTime.Now;
                model.ShortTitle=model.ShortTitle.Trim().Replace(" ","");
                var gallery = GalleryViewModel.Get(model);
                await _gallery.Create(gallery);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                await _logger?.AddException(e);
            }
            return View(new GalleryViewModel());
        }
        // GET
        public async Task<ActionResult> Index()
        {
            await _logger?.AddStat("","Index", "Album");
            var list=await _gallery.List();

            return View(list.Select(GalleryViewModel.Get));
        }
        // GET
        public async Task<ActionResult> Detail(string id)
        {
            try
            {
                await _logger?.AddStat(id,"Detail", "Album");

                var selectedgallery = await _gallery.Get(id);
                return View(GalleryViewModel.Get(selectedgallery));
            }
            catch (Exception e)
            {
                await _logger?.AddException(e);
            }
            return RedirectToAction("Index", "Album");
        }

        public async Task<IActionResult> GalleryManager()
        {            
            var list=await _gallery.List();

           return View(list.Select(GalleryViewModel.Get));
        }
        
        [Authorize]
        public async Task<IActionResult> Delete(long id)
        {
            var gallery=await _gallery.Get(id);

            return View(GalleryViewModel.Get(gallery));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(GalleryViewModel model)
        {
            try
            {
                await _gallery.Delete(GalleryViewModel.Get(model));
                return RedirectToAction("Index", "Album");
            }    
            catch (Exception e)
            {
              await _logger.AddException(e);
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Update(long id)
        {

            var gallery=await _gallery.Get(id);

            return View(GalleryViewModel.Get(gallery));
        }
        [HttpPost]
        public async Task<IActionResult> Update(GalleryViewModel model)
        {
            try
            {
               await _gallery.Update(GalleryViewModel.Get(model));
                return RedirectToAction("Index", "Album");

            }
            catch (Exception e)
            {
               await _logger.AddException(e);
            }
            return View(model);
        }
    }
}