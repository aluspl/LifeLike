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

        public static Page DataModel(PageViewModel model)
        {
           return new Page
            {
                Id=model.Id,
                Category = model.Category,
                FullName = model.FullName,
                ShortName = model.ShortName,
                PageOrder = model.PageOrder,
                Content = model.Content
            };   
        }
        public static PageViewModel ViewModel(Page model)
        {
            return new PageViewModel
            {
                Id=model.Id,
                Category = model.Category,
                FullName = model.FullName,
                ShortName = model.ShortName,
                PageOrder = model.PageOrder,
                Content = model.Content
            };   
        }
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
        public long LinkId { get; set; }
    }
}