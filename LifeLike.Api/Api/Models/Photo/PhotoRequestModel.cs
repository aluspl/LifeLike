using Microsoft.AspNetCore.Http;

namespace Api.Models.Photo
{
    public class PhotoRequestModel
    {
        public IFormFile PhotoStream { get; set; }
    }
}
