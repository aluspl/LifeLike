using System;
using Microsoft.AspNetCore.Http;

namespace LifeLike.Services.ViewModel
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