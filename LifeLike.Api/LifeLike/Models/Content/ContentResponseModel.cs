using LifeLike.Common.Enums;
using LifeLike.Models.Base;
using LifeLike.Models.Photo;

namespace LifeLike.Models.Content
{
    public class ContentResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public ContentCategory Category { get; set; }

        public string ContentInHTML { get; set; }

        public PhotoResponseModel Image { get; set; }
    }
}
