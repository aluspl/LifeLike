
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class VideoController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return            View();
        }
    }
}