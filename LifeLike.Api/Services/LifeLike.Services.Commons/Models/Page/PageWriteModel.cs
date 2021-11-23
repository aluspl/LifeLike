using System;

namespace LifeLike.Services.Commons.Models.Page
{
    public class PageWriteModel
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Summary { get; set; }

        public int Order { get; set; }

        public Guid? ImageId { get; set; }
    }
}
