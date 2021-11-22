using System;
using System.Collections.Generic;
using LifeLike.Database.Data.Entities.Link;

namespace LifeLike.Database.Data.Entities.Page
{
    public class PageEntity : BaseEntity
    {
        public PageEntity()
        {
            Categories = new List<CategoryEntity>();
            Contents = new List<ContentEntity>();
        }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public int Order { get; set; }

        public ICollection<CategoryEntity> Categories { get; set; }

        public ICollection<ContentEntity> Contents { get; set; }

        public LinkEntity Link { get; set; }

        public Guid? LinkId { get; set; }

        public DateTime Published { get; set; }

        public string ImageUrl { get; set; }
    }
}
