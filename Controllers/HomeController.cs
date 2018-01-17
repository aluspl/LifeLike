using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Controllers
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
        public async Task<IActionResult> Index()
        {
            await _logger?.AddStat("","Index", "Home");
            var pageCongif = new PageConfigModel
            {
                Rss1Url=await _config.Get(ConfigRepository.RSS1),
                Rss2Url=await _config.Get(ConfigRepository.RSS2),
                WelcomeText=await _config.Get(ConfigRepository.WelcomeText),
                WelcomeVideo=await _config.Get(ConfigRepository.WelcomeVideo)
            };
                
            return View(pageCongif);
        }


    }

    public class PageConfigModel
    {
        public Config Rss1Url { get; set; }
        public Config WelcomeText { get; set; }
        public Config Rss2Url { get; set; }
        public Config WelcomeVideo { get; set; }
    }
}