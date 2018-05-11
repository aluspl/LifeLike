using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IEventLogRepository _logger;
        private readonly IGalleryRepository _gallery;


        public AlbumController(IEventLogRepository logger,
            IPhotoRepository photoRepository,
            IGalleryRepository gallery,
            IHostingEnvironment hosting)
        {
            _logger = logger;
            _gallery = gallery;

        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                await _logger.AddStat("List", "Album");
                var list = await _gallery.List();
                return Json(list.Select(GalleryViewModel.Get));
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
                return null;
            }
          
        }
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            try
            {
                await _logger.AddStat(id,"Detail", "Album");

                var selectedgallery = await _gallery.Get(id);
                return Ok(GalleryViewModel.Get(selectedgallery));
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateGallery(GalleryViewModel model)
        {

            try
            {
                await _logger.AddStat(model.ShortTitle,"Create", "Album");
                model.Created=DateTime.Now;
                model.ShortTitle=model.ShortTitle.Trim().Replace(" ","");
                var gallery = GalleryViewModel.Get(model);
                return Ok(await _gallery.Create(gallery));
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return  new  BadRequestResult();

            }
        }
       
        [HttpDelete]
        public async Task<Result> Delete(GalleryViewModel model)
        {
            try
            {
                return await _gallery.Delete(GalleryViewModel.Get(model));
                 
            }    
            catch (Exception e)
            {
              await _logger.AddException(e);
               return Result.Failed;
            }
        }     
        [HttpPost]
        public async Task<Result> Update(GalleryViewModel model)
        {
            try
            {
                return await _gallery.Update(GalleryViewModel.Get(model));
                

            }
            catch (Exception e)
            {
               await _logger.AddException(e);
               return Result.Failed;
            }
        }
    }
}