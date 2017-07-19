
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using LifeLIke.Repositories;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
namespace LifeLIke.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IEventLogRepository _logger;
        private readonly IPhotoRepository _photos;
        private readonly IGalleryRepository _gallery;
        private  readonly IHostingEnvironment _hostingEnv;
        private readonly string _photoPath;


        public PhotoController(IEventLogRepository logger,
            IPhotoRepository photos,
            IGalleryRepository gallery,
            IHostingEnvironment hosting)
        {
            _logger = logger;
            _hostingEnv = hosting;
            _photos = photos;
            _gallery = gallery;
            _photoPath = Path.Combine("photos");


        }
        public IActionResult UploadFiles(long id)
        {
            var gallery = _gallery.Get(id);   
            return View(GalleryViewModel.GetViewForUpload(gallery));
        } 
        [HttpPost]
        public async Task<IActionResult> UploadFiles(UploadFileViewModel model )
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
            
                var uploadPath = Path.Combine(_hostingEnv.WebRootPath, "photos");

                if (model.Photo.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploadPath, model.Photo.FileName), FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(fileStream);
                    }
                    var photo = new Photo
                    {
                        FileName = model.Photo.FileName, Created = DateTime.Now, Title = model.Title,                 
                    };
                    _photos.Create(photo, model.GalleryId);
                }
                
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);
            }
       
            return RedirectToAction("Index", "Photos");

        }
        public IActionResult Detail(long id)
        {
            try
            {

                var photo=_photos.Get(id);
                var selectedPhoto=PhotoViewModel.Get(photo);
                var photos = Path.Combine(_hostingEnv.WebRootPath, "photos");
                return View(selectedPhoto);

            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);
            }
            return RedirectToAction("Index", "Photos");
        }   
        
        
        
        public bool IsFileSupported(IFormFile file)
        {
            var isSupported = false;

            switch (file.ContentType)
            {

                case ("image/gif"):
                    isSupported = true;
                    break;

                case ("image/jpeg"):
                    isSupported = true;
                    break;

                case ("image/png"):
                    isSupported = true;
                    break;


                case ("audio/mp3"):  
                    isSupported = true;
                    break;

                case ("audio/wav"):  
                    isSupported = true;
                    break;                                 
            }

            return isSupported;
        }
    }
}