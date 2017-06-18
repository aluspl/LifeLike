using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var menuItem = new List<LinkViewModel>
            {
              //  new MenuItem {Action = "Index", Controller = "Developer", Name = "Dev Projects"},
              //  new MenuItem {Action = "Index", Controller = "Photo", Name = "Photo Projects"},
               new LinkViewModel {Action = "Index", Controller = "Video", Name = "Video Projects"},
                new LinkViewModel {Action = "Index", Controller = "LifeLike", Name = "LifeLike: The Game"},
                new LinkViewModel {Action = "About", Controller = "Home", Name = "About Me"}
            };

            return View(menuItem);
        }
    }
}