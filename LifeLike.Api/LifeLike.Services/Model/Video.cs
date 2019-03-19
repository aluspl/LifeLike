using System;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.Extensions;

namespace LifeLike.Services.ViewModel
{
    public class Video
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public string YoutubeId   => Url.GetYoutubeId();
    }
}