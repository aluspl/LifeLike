using LifeLike.Models;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class HomeController : Controller
    {
        private IConfigRepository config;

        public HomeController(IConfigRepository config)
        {
            this.config = config;
        }
        public IActionResult Index()
        {
            var pageCongif = new PageConfigModel
            {
                Rss1Url=config.Get(ConfigRepository.RSS1)?.Value,
                Rss2Url=config.Get(ConfigRepository.RSS2)?.Value,
                WelcomeText=config.Get(ConfigRepository.WelcomeText)?.Value,
                WelcomeVideo=config.Get(ConfigRepository.WelcomeVideo)?.Value

            };
                
            return View(pageCongif);
        }

    
    }

    public class PageConfigModel
    {
        public string Rss1Url { get; set; }
        public string WelcomeText { get; set; }
        public string Rss2Url { get; set; }
        public string WelcomeVideo { get; set; }
    }
}