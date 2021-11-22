using System;
using LifeLike.Common.Enums;

namespace LifeLike.Database.Data.Entities.Page
{
    public class ContentEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public ContentCategory Category { get; set; }

        public PageEntity Page { get; set; }

        public Guid PageId { get; set; }
    }
}
