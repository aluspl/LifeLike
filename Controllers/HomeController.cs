using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {            
            return View();
        }

    
    }

   
}