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
    public class AuthorViewComponent : ViewComponent
    {
        private readonly ILinkRepository _context;

        public AuthorViewComponent(ILinkRepository context)
        {
            _context = context;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var model = new SidebarViewModel
            {
                Links = _context.List(LinkCategory.Sidebar).Select(LinkViewModel.Get)
            };



            return View(model);
        }
    }
}