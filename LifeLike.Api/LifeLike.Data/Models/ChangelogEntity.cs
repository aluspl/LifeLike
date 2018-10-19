using System;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class ChangelogEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string Link { get; set; }

    }
}