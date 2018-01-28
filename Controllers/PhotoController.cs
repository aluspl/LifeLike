
using System;
using System.IO;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace LifeLike.Controllers
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
        public async Task<IActionResult> UploadFiles(long id)
        {
            _logger?.AddStat(id.ToString(),"Upload", "Photo");

            var gallery =await _gallery.Get(id);   
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
                   await _photos.Create(photo, model.GalleryId);
                }
                
            }
            catch (Exception e)
            {
               await _logger?.AddException(e);
            }
       
            return RedirectToAction("Index", "Album");

        }
        public async Task<IActionResult> Detail(long id)
        {
            try
            {
               await  _logger?.AddStat(id.ToString(),"Detail", "Photo");

                var photo=await _photos.Get(id);
                var selectedPhoto=PhotoViewModel.Get(photo);
                var photos = Path.Combine(_hostingEnv.WebRootPath, "photos");
                return View(selectedPhoto);

            }
            catch (Exception e)
            {
                await _logger.AddException(e);
            }
            return RedirectToAction("Index", "Album");
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