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
    public class PhotoViewComponent : ViewComponent
    {
        private readonly ILinkRepository _context;

        public PhotoViewComponent(ILinkRepository context)
        {
            _context = context;
        }
        public async Task< IViewComponentResult> InvokeAsync(PhotoViewModel model)
        {
            return View(model);
        }
    }
}