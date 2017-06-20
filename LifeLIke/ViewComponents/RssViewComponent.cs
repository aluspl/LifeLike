using System;
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
        private IEventLogRepository eventLogRepo;

        public RssViewComponent(IEventLogRepository repository)
        {
            this.eventLogRepo=repository;
        }
        public async Task< IViewComponentResult> InvokeAsync(string URL)
        {
            try
            {
                var feed = await RssReader.ParseRss(URL,eventLogRepo);
                return View(feed.Take(3));
            }
            catch (Exception e)
            {
                eventLogRepo.AddExceptionLog(e);
                return View();
            }
            
        }
    }
}