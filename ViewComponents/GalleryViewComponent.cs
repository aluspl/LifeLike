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
    public class GalleryViewComponent : ViewComponent
    {
        private readonly ILinkRepository _context;

        public GalleryViewComponent(ILinkRepository context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(GalleryViewModel model)
        {
            return View(model);
        }
    }
}