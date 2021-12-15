using Microsoft.AspNetCore.Http;

namespace LifeLike.Models.Photo
{
    public class PhotoRequestModel
    {
        public IFormFile PhotoStream { get; set; }
    }
}
