using Microsoft.AspNetCore.Http;
using System;

namespace LifeLike.Shared.Model
{
    public class Photo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string ThumbUrl { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public string Camera { get; set; }
        public string Tags { get; set; }
        public string City { get; set; }
        public IFormFile Stream { get; set; }
       
    }
    
}