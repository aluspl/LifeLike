
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
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