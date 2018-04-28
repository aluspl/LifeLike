using System;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class Page
    {        
        [Key]
        public long Id { get; set; }

        [DataType(DataType.Text), Required]
        public string ShortName { get; set; }
        
        public string FullName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        
        public int PageOrder { get; set; }

        public PageCategory Category { get; set; }
        public long LinkId { get; set; }
        public DateTime Published { get; set; }
        public string ImageUrl { get; set; }
    }

    [Flags]
    public enum PageCategory
    {
        App,Game, Tutorial, Page, Post,
        Devs = App | Game
    }
}