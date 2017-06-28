using System;
using System.ComponentModel.DataAnnotations;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using Remotion.Linq.Clauses;

namespace LifeLike.Models
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
        
      
    }

    public enum PageCategory
    {
        App,Game, Tutorial, Page
    }
}