using System;
using System.ComponentModel.DataAnnotations;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.Extensions;

namespace LifeLike.Services.ViewModel
{
    public class Page
    {  
        public long Id { get; set; }
        [DataType(DataType.Text)] 
        public string ShortName { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.MultilineText)] 
        public string Content { get; set; }
        public int PageOrder { get; set; }
        public string Category { get; set; }
        public string IconName { get; set; }
        public long LinkId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Published { get; set; }
        public string Summary => Content.Summary();
        public string ContentInHTML => Content.ToHTML();
   
        public Link Link => new Link
        {
            Name = FullName,
            Action = ShortName,
            Category = "Menu",
            IconName = IconName,
            Controller = "Page"
        };
    }
}