using System;
using LifeLike.Data.Models.Enums;

namespace LifeLike.Repositories.ViewModel
{
    public class Video
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public VideoCategory Category { get; set; }
        public DateTime PublishDate { get; set; }
    }
}