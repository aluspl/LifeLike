using System.Collections.Generic;
using LifeLike.Database.Data.Entities.Page;

namespace LifeLike.Database.Data.Entities.Photo
{
    public class PhotoEntity : BaseEntity
    {
        private PhotoEntity()
        {
            Pages = new List<PageEntity>();
        }

        private PhotoEntity(string url, string filename, string thumbnailUrl, string thumbnailFilename)
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

        public  static PhotoEntity New(string url, string filename, string thumbnailFilename, string thumbnailUrl) => new PhotoEntity(url, filename, thumbnailUrl, thumbnailFilename);
    }
}
