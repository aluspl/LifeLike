using System.Collections.Generic;
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
            await _logger.AddStat("Menu", "Index", "Home");
            var list =   MenuList();

           // var list = await _links.List(LinkCategory.Menu);
            return Json(list.Select(LinkViewModel.Get));
        }

        private static List<Link> MenuList()
        {
            var context= new List<Link>();
          
         
            context.Add(new Link()
            {                
                Id=1,
                Action = "",
                Controller = "Posts",
                Name = "News",
                IconName = "pencil",

                Category = LinkCategory.Menu
            });

            context.Add(new Link()
            {
                Id=2,
                Action = "",
                Controller = "Albums",
                Name = "Albums",
                IconName = "camera",
                Category = LinkCategory.Menu
            });
            //    context.Add(new Link()
            // {
            //     Id=0,
            //     Action = "LifeLike",
            //     Controller = "Page",
            //     Name = "LifeLike: The Game",
            //     IconName = "king",

            //     Category = LinkCategory.Menu
            // });
            context.Add(new Link()
            {
                Id=3,
                Action = "",
                Controller = "Logs",
                Name = "Logs",
                IconName = "film",

                Category = LinkCategory.Menu
            });
              context.Add(new Link()
            {
                Id=4,
                Action = "",
                Controller = "Videos",
                Name = "Video Projects",
                IconName = "film",
                Category = LinkCategory.Menu
            });
            return context;
        }

        [HttpGet("Api/Config")]
        public async Task<IActionResult> GetList()
        {
            await _logger.AddStat("Configs","Index", "Home");
            var   config1=await _config.Get(Config.RSS1);
             var   config2=await _config.Get(Config.RSS2);
             var   config3=await _config.Get(Config.WelcomeText);
             var   config4=await _config.Get(Config.WelcomeVideo);
            var pageConfig = new PageConfigModel
            {
                Rss1Url=config1.Value,
                Rss2Url=config2.Value,
                WelcomeText=config3.Value,
                WelcomeVideo=config4.Value
            };

            return Json(pageConfig);
        }
    }
}