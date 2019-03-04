using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Web.Controllers
{
    public class UploadFile
    {
        [Required]
        public IFormFile PhotoStream { get; set; }
        [Required]
        public string Name { get; set; }
        public string Tags { get; set; }
        public string City { get; set; }
        public string Camera { get;  set; }
    }
}