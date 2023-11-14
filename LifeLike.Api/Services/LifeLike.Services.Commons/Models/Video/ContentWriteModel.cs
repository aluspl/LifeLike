using LifeLike.Common.Enums;

namespace LifeLike.Services.Commons.Models.Video;

public class ContentWriteModel
{
    public string Name { get; set; }

    public string Url { get; set; }

    public string Content { get; set; }

    public ContentCategory Category { get; set; }

    public Guid? ImageId { get; set; }
}