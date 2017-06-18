using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly LifeLikeContext _context;

        public MenuViewComponent(LifeLikeContext context)
        {
            _context = context;
        }
   
        public async Task< IViewComponentResult> InvokeAsync()
        {
                var list = _context.Links.Where(p => p.Category == LinkCategory.Menu).Select(p=>LinkViewModel.GetMenuLink(p)).ToList();
                return View(list);      
        }
    }
}