using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.ViewComponents
{
    public class AuthorViewComponent : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var model = new SidebarViewModel
            {
                Links = new List<LinkViewModel>
                {
                    new LinkViewModel {
                        Link = "https://github.com/aluspl/", 
                        IconName = "fire", 
                        Name = "Github"},
                    new LinkViewModel {
                        Link = "http://kawowipodroznicy.pl", 
                        IconName = "globe", 
                        Name = "Kawowi Podróżnicy"},
                    new LinkViewModel {
                        Link = "http://szymonmotyka.pl", 
                        IconName = "pencil", 
                        Name = "Personal Blog"},
                    new LinkViewModel {
                        Link = "https://www.linkedin.com/in/szymon-motyka-a7440b58/", 
                        IconName = "comment", 
                        Name = "LinkedIn"},
                    new LinkViewModel {
                        Link = "https://www.facebook.com/SzymonMotykapl/", 
                        IconName = "comment", 
                        Name = "Facebook"},
                    new LinkViewModel {
                    Link = "https://www.youtube.com/user/alusvanzuoo", 
                    IconName = "play", 
                    Name = "YT: Szymon Motyka"},
                new LinkViewModel {
                Link = "https://www.youtube.com/channel/UC-F1oSvOzczOSLAAsCLBvVA", 
                IconName = "play", 
                Name = "YT: Kawowi Podróżnicy"}
 
                }
            };

            return View(model);
        }
    }
}