using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using LifeLIke.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LifeLIke.ViewComponents
{
    public class RssViewComponent : ViewComponent
    {
        
        public async Task< IViewComponentResult> InvokeAsync(string URL)
        {
           var feed = await RssReader.ParseRss(URL);
           return View(feed.Take(3));
        }
    }
}