using System.Collections.Generic;
using LifeLike.Models;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class VideoController : Controller
    {
        private PortalContext _context;

        public VideoController(PortalContext context)
        {
            _context = context;
        }
        public IActionResult GalleryManager()
        {
            return View( );
        }
        // GET
        public ActionResult Index()
        {
            var items = new List<LinkViewModel>
            {
                new LinkViewModel {Link="https://www.youtube.com/watch?v=SC4o9JqI_aA", Name = "VLOG 4 : Żywiec"},
                new LinkViewModel {Link = "https://www.youtube.com/watch?v=kHMqiPbrKx8", Name = "VLOG 3 : W Aucie"},

                new LinkViewModel {Link = "https://www.youtube.com/watch?v=Qi5tp0eZHt8", Name = "VLOG 2 : Podsumowanie DSP 2017"},

                new LinkViewModel {Link = "1Gjnnq93X9E", Name = "VLOG 1 : DSP 2017"},
                new LinkViewModel {Link = "Q8v0KHMtwBs", Name = "Kawowe Podróże: Islandia"},
                new LinkViewModel {Link = "QnL0mgOAYfQ", Name = "Kawowe Podróże: Grecja"},

            };
            return    View(items);
        }
    }
}