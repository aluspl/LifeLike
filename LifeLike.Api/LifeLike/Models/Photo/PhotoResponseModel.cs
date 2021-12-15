using LifeLike.Models.Base;

namespace LifeLike.Models.Photo
{
    public class PhotoResponseModel : BaseResponseModel
    {
        public string Url { get; set; }

        public string ThumbUrl { get; set; }

        public string Filename { get; set; }

        public string ThumbFilename { get; set; }
    }
}
