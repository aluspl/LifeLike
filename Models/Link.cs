using System;
using System.ComponentModel.DataAnnotations;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;

namespace LifeLike.Models
{
    public class Link
    {
        [Key]
        public long Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconName { get; set; }
        public int Order { get; set; }
        public LinkCategory Category { get; set; }
        
      
    }
}