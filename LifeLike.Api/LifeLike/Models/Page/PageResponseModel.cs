using System;
using System.Collections.Generic;
using LifeLike.Models.Base;
using LifeLike.Models.Category;
using LifeLike.Models.Content;
using LifeLike.Models.Photo;

namespace LifeLike.Models.Page
{
    public class PageResponseModel : BaseResponseModel
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Summary { get; set; }

        public int Order { get; set; }

        public ICollection<CategoryResponseModel> Categories { get; set; }

        public ICollection<ContentResponseModel> Contents { get; set; }

        public string IconName { get; set; }

        public PhotoResponseModel Image { get; set; }

        public DateTime Published { get; set; }
    }
}
