using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services;
using LifeLike.Services.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IConfigService _config;
        private readonly ILogService _logger;
        private readonly ILinkService _link;

        public HomeController(IConfigService config, ILogService logger, 
        SignInManager<User> signInManager,
        ILinkService link)
        {
            _link= link;
            _logger = logger;
            _config = config;
        }
        // [HttpGet]
        // [AllowAnonymous]
        // public IActionResult Index()
        // {
        //     return View();
        // }
        [HttpGet("Api/Menu")]
        [AllowAnonymous]
        public IActionResult GetMenuLinks()
        {
            var isLogged = User.Identity.IsAuthenticated;

            var list = _link.List(LinkCategory.Menu);

            return Ok(list);
        }


        [HttpGet("Api/Config")]
        [AllowAnonymous]
        public IActionResult GetList()
        {
            var configs = _config.List();
            var isLogged = User.Identity.IsAuthenticated;

            Debug.WriteLine(configs.ToJSON());
            return Ok(configs);
        }
    }
}