using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Services;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService service;

        public AlbumController(ILogService logger,
            IPhotoService photoRepository,
            IAlbumService gallery,
            IHostingEnvironment hosting)
        {
            service = gallery;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = service.List();
                return Json(list);
            }
            catch (Exception)
            {
                return null;
            }

        }
        [HttpGet("Detail/{id}")]
        public IActionResult Detail(string id)
        {           
                var selectedgallery = service.Get(id);
                return Ok(selectedgallery);
           
        }
        [HttpPost]
        public IActionResult CreateGallery(Album model)
        {
                model.Created = DateTime.Now;
                model.ShortTitle = model.ShortTitle.Trim().Replace(" ", "");
                return Ok(service.Create(model));      
        }

        [HttpDelete("Id")]
        [Authorize]
        public IActionResult Delete(long id)
        {           
                if (ModelState.IsValid)
                {
                    return Ok(service.Delete(id));
                }
                return BadRequest();          
        }
        [HttpPut]
        [Authorize]
        public IActionResult Update(Album model)
        {
                if (ModelState.IsValid)
                {
                    return Ok(service.Update(model));
                }
                return BadRequest();
        }
    }
}