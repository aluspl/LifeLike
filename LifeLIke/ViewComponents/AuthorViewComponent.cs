using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.ViewComponents
{
    public class AuthorViewComponent : ViewComponent
    {
        private readonly LifeLikeContext _context;

        public AuthorViewComponent(LifeLikeContext context)
        {
            _context = context;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var model = new SidebarViewModel
            {
                Links = _context.Links.Where(p => p.Category == LinkCategory.Sidebar)
                    .Select(p => LinkViewModel.GetSidebarLink(p)).ToList()
            };



            return View(model);
        }
    }
}