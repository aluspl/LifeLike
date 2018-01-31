using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IConfigRepository _config;
        private readonly IEventLogRepository _logger;
        private ILinkRepository _links;

        public HomeController(IConfigRepository config, IEventLogRepository logger, ILinkRepository link)
        {
            _logger = logger;
            _config = config;
            _links = link;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Api/Menu")]
        public async Task<IActionResult> GetMenuLinks()
        {
            await _logger.AddStat("Menu","Index", "Home");

            var list = await _links.List(LinkCategory.Menu);
            return Json(list.Select(LinkViewModel.Get));
        }
        [HttpGet("Api/Config")]
        public async Task<IActionResult> GetList()
        {
            await _logger.AddStat("Configs","Index", "Home");
            var pageConfig = new PageConfigModel
            {
                Rss1Url=await _config.Get(Config.RSS1),
                Rss2Url=await _config.Get(Config.RSS2),
                WelcomeText=await _config.Get(Config.WelcomeText),
                WelcomeVideo=await _config.Get(Config.WelcomeVideo)
            };

            return Json(pageConfig);
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