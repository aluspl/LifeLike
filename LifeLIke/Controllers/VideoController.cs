
using System.Collections.Generic;
using LifeLike.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
{
    public class VideoController : Controller
    {
        // GET
        public ActionResult Index()
        {

            var items = new List<MenuItem>
            {
                new MenuItem {Link = "1Gjnnq93X9E", Name = "DSP 2017"},
                new MenuItem {Link = "Q8v0KHMtwBs", Name = "Kawowe Podróże: Islandia"},
                new MenuItem {Link = "QnL0mgOAYfQ", Name = "Kawowe Podróże: Grecja"},

            };
            return    View(items);
        }
    }
}