using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Web.Utils;
using LifeLike.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace LifeLike.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly IConfigRepository _config;
        private readonly IEventLogRepository _logger;
        private readonly ILinkRepository _links;
        private readonly SignInManager<User> _userManager;

        public HomeController(IConfigRepository config, IEventLogRepository logger, 
        SignInManager<User> signInManager,
        ILinkRepository link)
        {
            _logger = logger;
            _config = config;
            _links = link;
                        _userManager = signInManager;

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
        [Authorize]
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
                WelcomeVideo=HtmlUtils.GetYoutubeId(config4.Value)
            };
            Debug.WriteLine(pageConfig.WelcomeVideo);
            return Json(pageConfig);
        }
    }
}