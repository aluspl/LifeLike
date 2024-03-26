using LifeLike.Services.Commons.Models.Base;

namespace LifeLike.Services.Commons.Models.Photo;

public class PhotoModel : BaseModel
{
    public string Url { get; set; }

    public string ThumbnailUrl { get; set; }

    public string Filename { get; set; }

    public string ThumbnailFilename { get; set; }
}