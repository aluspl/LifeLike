using System.Collections.Generic;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class VideoController : Controller
    {
        // GET
        public ActionResult Index()
        {

            var items = new List<LinkViewModel>
            {
                new LinkViewModel {Link = "1Gjnnq93X9E", Name = "DSP 2017"},
                new LinkViewModel {Link = "Q8v0KHMtwBs", Name = "Kawowe Podróże: Islandia"},
                new LinkViewModel {Link = "QnL0mgOAYfQ", Name = "Kawowe Podróże: Grecja"},

            };
            return    View(items);
        }
    }
}