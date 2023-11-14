using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Controllers;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Interfaces.Media;
using LifeLike.Services.Commons.Models.Photo;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Area.Admin;

[Area("admin")]
[Route("[area]/[controller]")]
public class PhotoController : BaseAuthController
{
    private readonly IPhotoService _photoService;
    private readonly IStorageService _storageService;

    public PhotoController(ILogger logger,
        IPhotoService photoService,
        IStorageService storageService,
        IWebHostEnvironment hosting)
    {
        _photoService = photoService;
        _storageService = storageService;
    }

    [HttpPost, DisableRequestSizeLimit]
    [Return(typeof(PhotoModel))]
    public async Task<IActionResult> Create(PhotoWriteModel model)
    {
        GetImage(model);

        var photo = await _storageService.Add(model.PhotoStream);

        var item = await _photoService.Create(photo);
        return GetResult(item);
    }

    [HttpGet]
    [Return(typeof(ICollection<PhotoModel>))]
    public async Task<IActionResult> List()
    {
        var photos = await _photoService.List();
        return GetResult(photos);
    }

    [HttpGet("{id:guid}")]
    [Return(typeof(PhotoModel))]
    public async Task<IActionResult> Detail(Guid id)
    {
        var photo = await _photoService.Get(id);
        return GetResult(photo);
    }

    [HttpDelete("{id:guid}")]
    [ReturnEmpty]
    public IActionResult Delete(Guid id)
    {
        _photoService.Delete(id);
        return GetResult();
    }

    private void GetImage(PhotoWriteModel model)
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