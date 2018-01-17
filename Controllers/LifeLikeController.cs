using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class LifeLikeController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return            View();
        }
        public ActionResult WebPlayer()
        {
            return            View();
        }
    }
}