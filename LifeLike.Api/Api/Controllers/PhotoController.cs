using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : BaseController
    {
        private readonly IPhotoService _photos;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnv;

        public PhotoController(ILogger logger,
            IPhotoService photos,
            IWebHostEnvironment hosting)
        {
            _logger = logger;
            _hostingEnv = hosting;
            _photos = photos;
        }

        [HttpPost("Create"), DisableRequestSizeLimit]
        public async Task<IActionResult> Create(UploadFile model)
        {
            if (model.PhotoStream == null)
            {
                if (Request.Form.Files.Count == 0) model.PhotoStream = null;
                else
                {
                    var doc = Request.Form.Files[0];
                    model.PhotoStream = doc;
                }
            }
            if (!ModelState.IsValid)
                return BadRequest(Result.Failed);

            var photo = new Photo
            {
                FileName = model.PhotoStream.FileName,
                Created = DateTime.Now,
                Title = model.Name,
                Stream = model.PhotoStream,
                Tags = model.Tags,
                City = model.City,
                Camera = model.Camera
            };
            var item = await _photos.Create(photo);
            return Ok(item);
        }

        [HttpGet]
        public IActionResult List()
        {
            var photo = _photos.List();
            return Ok(photo);
        }
        [HttpGet("Detail")]
        public IActionResult Detail(string id)
        {
            var photo = _photos.Get(id);
            return Ok(photo);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            if (id == null) return BadRequest();
            var result = _photos.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromBody] Photo model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var value = _photos.Update(model);
            return Ok(value);
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