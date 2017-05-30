using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLIke.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.ViewComponents
{
    public class AuthorViewComponent : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var model = new SidebarDataModel
            {
                Links = new List<MenuItem>
                {
                    new MenuItem {Link = "http://kawowipodroznicy.pl", IconName = "glyphicon-globe", Name = "Kawowi Podróżnicy"},
                    new MenuItem {Link = "http://szymonmotyka.pl", IconName = "glyphicon-pencil", Name = "Personal Blog"},
                    new MenuItem {Link = "https://www.linkedin.com/in/szymon-motyka-a7440b58/", IconName = "glyphicon-comment", Name = "LinkedIn"},
                    new MenuItem {Link = "https://www.facebook.com/SzymonMotykapl/", IconName = "glyphicon-comment", Name = "Facebook"}
 
                }
            };

            return View(model);
        }
    }
}