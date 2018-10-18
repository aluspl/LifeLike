using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
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
        public async Task<IActionResult> GetMenuLinks()
        {
            var   isLogged = User.Identity.IsAuthenticated;

            await _logger.AddStat("Menu", "Index", "Home");
            var list = _link.List(LinkCategory.Menu);

            return Ok(list);
        }


        [HttpGet("Api/Config")]
        public async Task<IActionResult> GetList()
        {
            await _logger.AddStat("Configs","Index", "Home");
            var configs =await _config.List();
            
            Debug.WriteLine(configs.ToJSON());
            return Ok(configs);
        }
    }
}