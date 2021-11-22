using Api.Models.Base;
using Api.Models.Photo;
using LifeLike.Common.Enums;

namespace Api.Models.Content
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
