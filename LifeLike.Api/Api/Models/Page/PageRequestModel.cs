using System;

namespace Api.Models.Page
{
    public class PageRequestModel
    {
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Content { get; set; }

        public int PageOrder { get; set; }

        public string Category { get; set; }

        public string IconName { get; set; }

        public Guid? ImageId { get; set; }

        public string Summary { get; set; }

        public string ContentInHTML { get; set; }
    }
}
