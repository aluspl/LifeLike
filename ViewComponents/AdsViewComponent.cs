using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.ViewComponents
{
    public class AdsViewComponent : ViewComponent
    {
        private readonly IConfigRepository _context;

        public AdsViewComponent(IConfigRepository context)
        {
            _context = context;
        }
        public async Task< IViewComponentResult> InvokeAsync(string width, string height)
        {
            AdViewModel model=new AdViewModel
            {
                Slot=_context.Get(ConfigRepository.ADSLOT)?.Value,
                Client=_context.Get(ConfigRepository.ADCLIENT)?.Value,
                Width=width,
                Height=height

            };

            return View(model);
        }
    }
}