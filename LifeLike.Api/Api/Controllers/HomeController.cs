using LifeLike.Data.Models;
using LifeLike.Services;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Structures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LifeLike.Web.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IConfigService _config;
        private readonly ILogger _logger;
        private readonly ILinkService _link;

        public HomeController(IConfigService config, ILogger logger, 
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
            return Ok(configs);
        }
    }
}