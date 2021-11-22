using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Models.Base;
using LifeLike.Services.Commons.Models.Photo;

namespace LifeLike.Services.Commons.Models.Video
{
    public class ContentReadModel : BaseReadModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public ContentCategory Category { get; set; }

        public string ContentInHTML { get; set; }

        public PhotoReadModel Image { get; set; }
    }
}
