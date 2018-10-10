using System;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class PhotoEntity
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public DateTime Created { get; set; }
        public string Camera { get; set; }
        public  GalleryEntity Gallery { get; set; }
    }
}