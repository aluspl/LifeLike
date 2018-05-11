using System;
using System.ComponentModel.DataAnnotations;
using LifeLike.Data.Models.Enums;

namespace LifeLike.Data.Models
{
    public class Video
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public VideoCategory Category { get; set; }
    }
}