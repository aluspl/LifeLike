using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using LifeLike.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LifeLike.ViewComponents
{
    public class RssViewComponent : ViewComponent
    {
        private readonly IRssReaderService RssService;

        public RssViewComponent(IRssReaderService repository)
        {
            this.RssService=repository;
        }
        public async Task< IViewComponentResult> InvokeAsync(string URL, int TOP)
        {

                var feed = await RssService.Parse(URL, FeedType.RSS);
                return View(feed.Take(TOP));
         
            
        }
    }
}