using LifeLike.Common.Enums;
using LifeLike.Database.Data.Entities.Photo;

namespace LifeLike.Database.Data.Entities.Page;

public class ContentEntity : BaseEntity
{
    public string Name { get; set; }

    public string Url { get; set; }

    public string Content { get; set; }

    public int Order { get; set; }

    public ContentCategory Category { get; set; }

    public PageEntity Page { get; set; }

    public Guid PageId { get; set; }
 
    public ImageEntity Image { get; set; }

    public Guid ImageId { get; set; }
}