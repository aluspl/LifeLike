using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Models.Photo;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Interfaces.Media;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LifeLike.Area.Admin
{
    [Area("admin")]
    [Route("[area]/[controller]")]
    public class PhotoController : BaseAuthController
    {
        private readonly IPhotoService _photoService;
        private readonly IStorageService _storageService;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IMapper _mapper;

        public PhotoController(ILogger logger,
            IPhotoService photoService,
            IStorageService storageService,
            IWebHostEnvironment hosting,
            IMapper mapper)
        {
            _logger = logger;
            _hostingEnv = hosting;
            _mapper = mapper;
            _photoService = photoService;
            _storageService = storageService;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Return(typeof(PhotoResponseModel))]
        public async Task<IActionResult> Create(PhotoRequestModel model)
        {
            GetImage(model);

            var photo = await _storageService.Add(model.PhotoStream);

            var item = await _photoService.Create(photo);
            var result = _mapper.Map<PhotoResponseModel>(item);
            return GetResult(result);
        }

        [HttpGet]
        [Return(typeof(ICollection<PhotoResponseModel>))]
        public async Task<IActionResult> List()
        {
            var photos = await _photoService.List();
            var result = _mapper.Map<ICollection<PhotoResponseModel>>(photos);
            return GetResult(result);
        }

        [HttpGet("{id:guid}")]
        [Return(typeof(PhotoResponseModel))]
        public async Task<IActionResult> Detail(Guid id)
        {
            var photo = await _photoService.Get(id);
            var result = _mapper.Map<PhotoResponseModel>(photo);
            return GetResult(result);
        }

        [HttpDelete("{id:guid}")]
        [ReturnEmpty]
        public IActionResult Delete(Guid id)
        {
            _photoService.Delete(id);
            return GetResult();
        }

        private void GetImage(PhotoRequestModel model)
        {
            if (model.PhotoStream != null)
            {
                return;
            }

            if (Request.Form.Files.Count == 0)
            {
                model.PhotoStream = null;
            }
            else
            {
                var doc = Request.Form.Files[0];
                model.PhotoStream = doc;
            }
        }
    }
}
