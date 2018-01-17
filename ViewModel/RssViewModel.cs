using System;
using LifeLike.Models.Enums;
using LifeLike.Utils;

namespace LifeLike.ViewModel
{
    public class RssViewModel
    { 
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public FeedType FeedType { get; set; }
        public DateTime PublishDate { get; set; }
    }
}