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

        // GET
        public ActionResult Index()
        {
            var items = new List<LinkViewModel>
            {
                new LinkViewModel {Link = "8LtiKIezUIQ", Name = "VLOG 2 Podsumowanie DSP 2017"},

                new LinkViewModel {Link = "1Gjnnq93X9E", Name = "VLOG 1 DSP 2017"},
                new LinkViewModel {Link = "Q8v0KHMtwBs", Name = "Kawowe Podróże: Islandia"},
                new LinkViewModel {Link = "QnL0mgOAYfQ", Name = "Kawowe Podróże: Grecja"},

            };
            return    View(items);
        }
    }
}