using System;
using System.Linq.Expressions;
using LifeLike.Models;

namespace LifeLike.ViewModel
{
    public class LinkViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        
        public string Name { get; set; }
        public string Link { get; set; }

        public string IconName { get; set; }

        public static LinkViewModel GetMenuLink(LinkDataModel model)
        {
            return new LinkViewModel
            {
                Action = model.Action,
                Controller = model.Controller,
                Name = model.Name
            };
        }
        public static LinkViewModel GetSidebarLink(LinkDataModel model)
        {
            return new LinkViewModel
            {
                Link = model.Link,
                IconName = model.IconName,
                Name = model.Name
            };
        }
        public static LinkViewModel GetVideoLink(LinkDataModel model)
        {
            return new LinkViewModel
            {
                Link = model.Link,
                Name = model.Name
            };
        }
    }
}