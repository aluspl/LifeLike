using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
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