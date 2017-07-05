
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LifeLike.Repositories;
using LifeLIke.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IEventLogRepository _logRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IHostingEnvironment _environment;

        public PhotoController(IEventLogRepository logRepository, IPhotoRepository photoRepository, IHostingEnvironment environment)
        {
            _logRepository = logRepository;
            _photoRepository = photoRepository;
            _environment = environment;

        }
        // GET
        public ActionResult Index()
        {
            
            return   View();
        }


        public IActionResult UploadPhoto()
        {
            
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadPhoto (ICollection<IFormFile> files)
        {        
            var uploads = Path.Combine(_environment.WebRootPath, "photo");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View();
                 
        }
    }
}