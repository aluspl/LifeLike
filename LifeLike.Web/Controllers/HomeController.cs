using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigRepository _config;
        private readonly IEventLogRepository _logger;

        public HomeController(IConfigRepository config, IEventLogRepository logger)
        {
            _logger = logger;
            _config = config;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<PageConfigModel> GetList()
        {
            await _logger.AddStat("GetList","Index", "Home");
            var pageConfig = new PageConfigModel
            {
                Rss1Url=await _config.Get(Config.RSS1),
                Rss2Url=await _config.Get(Config.RSS2),
                WelcomeText=await _config.Get(Config.WelcomeText),
                WelcomeVideo=await _config.Get(Config.WelcomeVideo)
            };

            return pageConfig;
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