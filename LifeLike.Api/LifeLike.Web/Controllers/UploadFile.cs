using Microsoft.AspNetCore.Http;

namespace LifeLike.Web.Controllers
{
    public class UploadFile
    {
        public IFormFile PhotoStream { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public string City { get; set; }
        public string Camera { get;  set; }
    }
}