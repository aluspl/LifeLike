using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var menuItem = new List<MenuItem>
            {
                new MenuItem {Action = "Index", Controller = "Home", Name = "Main Page"},
                new MenuItem {Action = "About", Controller = "Home", Name = "About Me"},
                new MenuItem {Action = "Index", Controller = "LifeLike", Name = "LifeLike: The Game"}
            };

            return View(menuItem);
        }
    }
}