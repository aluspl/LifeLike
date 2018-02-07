using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class Gallery
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        
        public ICollection<Photo> Photos { get; set; }
        public string ShortTitle { get; set; }
    }
}