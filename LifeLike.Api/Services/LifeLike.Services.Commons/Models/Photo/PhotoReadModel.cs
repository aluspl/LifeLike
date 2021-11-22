using LifeLike.Services.Commons.Models.Base;

namespace LifeLike.Services.Commons.Models.Photo
{
    public class PhotoReadModel : BaseReadModel
    {
        public string Url { get; set; }

        public string ThumbUrl { get; set; }

        public string Filename { get; set; }

        public string ThumbFilename { get; set; }
    }
}
