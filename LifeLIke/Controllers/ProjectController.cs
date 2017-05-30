using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class ProjectController : Controller
    {
        // GET
        public ActionResult Index()
        {
            
            return View();
        }
    }
}