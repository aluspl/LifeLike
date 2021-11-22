using System;
using System.Collections.Generic;
using LifeLike.Services.Commons.Models.Base;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Services.Commons.Models.Page
{
    public class PageReadModel : BaseReadModel
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Summary { get; set; }

        public int Order { get; set; }

        public ICollection<CategoryReadModel> Categories { get; set; }

        public ICollection<ContentReadModel> Contents { get; set; }

        public PhotoReadModel Image { get; set; }

        public DateTime Published { get; set; }
    }
}
