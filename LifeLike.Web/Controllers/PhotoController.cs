using System;
using System.IO;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Services;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photos;
        private readonly IAlbumService _album;
        private readonly IHostingEnvironment _hostingEnv;


        public PhotoController(ILogService logger,
            IPhotoService photos,
            IAlbumService album,
            IHostingEnvironment hosting)
        {
            _hostingEnv = hosting;
            _photos = photos;
            _album = album;
            Path.Combine("photos");
        }
        [HttpGet("UploadFiles")]
        public UploadFileViewModel UploadFiles(long id)
        {
            // await _logger.AddStat(id.ToString(), "Upload", "Photo");

            var gallery = _album.Get(id);
            return Album.GetViewForUpload(gallery);
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles(UploadFileViewModel model)
        {
                if (!ModelState.IsValid) return BadRequest(Result.Failed);

                var uploadPath = Path.Combine(_hostingEnv.WebRootPath, "photos");

                if (model.Photo.Length <= 0) return BadRequest(Result.Failed);
                using (var fileStream = new FileStream(Path.Combine(uploadPath, model.Photo.FileName), FileMode.Create))
                {
                    await model.Photo.CopyToAsync(fileStream);
                }

                var photo = new Photo
                {
                    FileName = model.Photo.FileName,
                    Created = DateTime.Now,
                    Title = model.Title
                };
                return Ok( _photos.Create(photo, model.GalleryId));
        }
        [HttpGet("Detail")]
        public IActionResult Detail(long id)
        {
                var photo = _photos.Get(id);
                return Ok(photo);            
        }

        private bool IsFileSupported(IFormFile file)
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