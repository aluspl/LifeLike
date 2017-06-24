using System;
using System.ComponentModel.DataAnnotations;
using LifeLike.Models.Enums;

namespace LifeLike.Models
{
    public class Changelog
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string Link { get; set; }

    }
}