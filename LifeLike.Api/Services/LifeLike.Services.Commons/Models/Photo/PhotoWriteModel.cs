using Microsoft.AspNetCore.Http;

namespace LifeLike.Services.Commons.Models.Photo;

public class PhotoWriteModel
{
    public string Url { get; set; }

    public string ThumbnailUrl { get; set; }

    public string Filename { get; set; }

    public string ThumbnailFilename { get; set; }
 
    public IFormFile PhotoStream { get; set; }
}