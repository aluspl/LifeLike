using System.ComponentModel.DataAnnotations;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LifeLike.ViewModel
{
    public class PageViewModel
    {
        [DataType(DataType.Text), Required]
        public string ShortName { get; set; }
        
        public string FullName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        
        public int PageOrder { get; set; }
        public PageCategory Category { get; set; }

        public Page DataModel => new Page
        {
            Id=Id,
            Category = Category,
            FullName = FullName,
            ShortName = ShortName,
            PageOrder = PageOrder,
            Content = Content
        };

        public long Id { get; set; }

        public Link Link => new Link
        {
            Name = FullName,
            Action = ShortName,
            Category = LinkCategory.Menu,
            IconName = IconName,
            Controller = "Page"
        };

        public string IconName { get; set; }
    }
}