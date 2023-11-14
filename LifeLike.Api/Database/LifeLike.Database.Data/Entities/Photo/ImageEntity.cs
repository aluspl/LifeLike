using LifeLike.Database.Data.Entities.Page;

namespace LifeLike.Database.Data.Entities.Photo;

public class ImageEntity : BaseEntity
{
    private ImageEntity()
    {
        Pages = new List<PageEntity>();
    }

    private ImageEntity(string url, string filename, string thumbnailUrl, string thumbnailFilename)
        : base()
    {
        Url = url;
        Filename = filename;
        ThumbnailUrl = thumbnailUrl;
        ThumbnailFilename = thumbnailFilename;
    }

    public string Url { get; private set; }

    public string ThumbnailUrl { get; private set; }

    public string Filename { get; private set; }

    public string ThumbnailFilename { get; private set; }

    public IEnumerable<PageEntity> Pages { get; private set; }

    public  static ImageEntity New(string url, string filename, string thumbnailFilename, string thumbnailUrl) => new ImageEntity(url, filename, thumbnailUrl, thumbnailFilename);
}