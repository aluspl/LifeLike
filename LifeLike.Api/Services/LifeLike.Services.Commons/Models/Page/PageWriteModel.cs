using System;
using System.Collections.Generic;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Services.Commons.Models.Page
{
    public class PageWriteModel
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Summary { get; set; }

        public int Order { get; set; }

        public ICollection<CategoryWriteModel> Categories { get; set; }

        public ICollection<ContentWriteModel> Contents { get; set; }

        public Guid? ImageId { get; set; }

        public DateTime Published { get; set; }
    }
}
