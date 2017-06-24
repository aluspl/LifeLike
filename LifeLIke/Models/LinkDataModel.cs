using System;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;

namespace LifeLike.Models
{
    public class LinkDataModel
    {
        public long Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string IconName { get; set; }
        public LinkCategory Category { get; set; }
        
      
    }
}