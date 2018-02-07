using System.ComponentModel.DataAnnotations;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;

namespace LifeLike.Web.ViewModel
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
        public string IconName { get; set; }
        public long LinkId { get; set; }
        public long Id { get; set; }

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

        public Link Link => new Link
        {
            Name = FullName,
            Action = ShortName,
            Category = LinkCategory.Menu,
            IconName = IconName,
            Controller = "Page"
        };

      
    }
}