using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ILinkRepository _context;

        public MenuViewComponent(ILinkRepository context)
        {
            _context = context;
        }
   
        public async Task< IViewComponentResult> InvokeAsync()
        {
                var list = _context.List(LinkCategory.Menu).Select(LinkViewModel.Get).ToList();
                return View(list);      
        }
    }
}