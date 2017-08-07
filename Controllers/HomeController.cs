using LifeLike.Models;
using LifeLike.Repositories;
using LifeLIke.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigRepository _config;
        private readonly IEventLogRepository _logger;

        public HomeController(IConfigRepository config, IEventLogRepository logger)
        {
            this._logger = logger;
            this._config = config;
        }
        public IActionResult Index()
        {
            _logger.AddStat("","Index", "Home");
            var pageCongif = new PageConfigModel
            {
                Rss1Url=_config.Get(ConfigRepository.RSS1)?.Value,
                Rss2Url=_config.Get(ConfigRepository.RSS2)?.Value,
                WelcomeText=_config.Get(ConfigRepository.WelcomeText)?.Value,
                WelcomeVideo=_config.Get(ConfigRepository.WelcomeVideo)?.Value

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