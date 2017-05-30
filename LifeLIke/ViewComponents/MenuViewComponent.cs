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
                new MenuItem {Action = "Index", Controller = "Developer", Name = "Dev Projects"},
                new MenuItem {Action = "Index", Controller = "Photo", Name = "Photo Projects"},
                new MenuItem {Action = "Index", Controller = "Video", Name = "Video Projects"},
                new MenuItem {Action = "Index", Controller = "LifeLike", Name = "LifeLike: The Game"},

                new MenuItem {Action = "About", Controller = "Home", Name = "About Me"}
            };

            return View(menuItem);
        }
    }
}