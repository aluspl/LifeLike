
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

namespace LifeLIke.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IEventLogRepository logger;
        private readonly IPhotoRepository _photoRepository;
        private readonly IGalleryRepository _gallery;


        public PhotoController(IEventLogRepository logger,
            IPhotoRepository photoRepository,
            IGalleryRepository gallery)
        {
            logger = logger;
            _photoRepository = photoRepository;
            _gallery = gallery;

        }
     
        [Authorize]
        public IActionResult Delete(long id)
        {
            throw new  NotImplementedException();
        }      
    }
}