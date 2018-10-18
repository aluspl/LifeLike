using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Services.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly ILogService _logger;
        private readonly IAlbumService _galleryRepository;


        public AlbumController(ILogService logger,
            IPhotoService photoRepository,
            IAlbumService gallery,
            IHostingEnvironment hosting)
        {
            _logger = logger;
            _galleryRepository = gallery;

        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                await _logger.AddStat("List", "Album");
                var list = await _galleryRepository.List();
                return Json(list);
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

                var selectedgallery = await _galleryRepository.Get(id);
                return Ok(selectedgallery);
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return null;
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateGallery(Gallery model)
        {

            try
            {
                await _logger.AddStat(model.ShortTitle,"Create", "Album");
                model.Created=DateTime.Now;
                model.ShortTitle=model.ShortTitle.Trim().Replace(" ","");
                return Ok(await _galleryRepository.Create(model));
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return  new  BadRequestResult();
            }
        }
       
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Gallery model)
        {
            try
            {    
                 if (ModelState.IsValid)
                {            
                    return Ok(await _galleryRepository.Delete(model));                 
                }
                return BadRequest();

            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return BadRequest();
            }
        }     
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Gallery model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     return Ok(await _galleryRepository.Update(model));
                }
                return BadRequest();

            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return BadRequest();
            }
        }
    }
}