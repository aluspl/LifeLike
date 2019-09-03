using System;
using System.ComponentModel.DataAnnotations;
using LifeLike.Services.Extensions;

namespace LifeLike.Services.ViewModel
{
    public class Page
    {
        public string Id { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Content { get; set; }
        public int PageOrder { get; set; }
        public string Category { get; set; }
        public string IconName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Published { get; set; }
        public string Summary => Content.Summary();
        public string ContentInHTML => Content.ToHTML();       
    }
}