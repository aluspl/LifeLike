using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Models.Base;
using LifeLike.Services.Commons.Models.Photo;

namespace LifeLike.Services.Commons.Models.Video;

public class ContentModel : BaseModel
{
    public string Name { get; set; }

    public string Url { get; set; }

    public ContentCategory Category { get; set; }

    public string ContentInHTML { get; set; }

    public PhotoModel Image { get; set; }

    public string Content { get; set; }
}