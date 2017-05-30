
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class PhotoController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return   View();
        }
    }
}