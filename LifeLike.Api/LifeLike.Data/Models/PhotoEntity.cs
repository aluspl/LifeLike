using LifeLike.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeLike.Data.Models
{
    public class PhotoEntity : Entity
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public DateTime Created { get; set; }
        public string Camera { get; set; }
        public string Tags { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
        public string ThumbUrl { get; set; }
    }
}