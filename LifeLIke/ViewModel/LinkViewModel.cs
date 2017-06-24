using System;
using System.Linq.Expressions;
using LifeLike.Models;
using LifeLike.Models.Enums;

namespace LifeLike.ViewModel
{
    public class LinkViewModel
    {
        public long Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        
        public string Name { get; set; }
        public string Link { get; set; }

        public string IconName { get; set; }
        public LinkCategory Category { get; set; }

        public static LinkDataModel Get(LinkViewModel model)
        {
            return new LinkDataModel
            {
                Id=model.Id,
                Action = model.Action,
                Controller = model.Controller,
                Name = model.Name,
                Link = model.Link,
                IconName = model.IconName,
                Category=model.Category               
            };

        }
        public static LinkViewModel Get(LinkDataModel model)
        {
            return new LinkViewModel
            {
                Id=model.Id,
                Action = model.Action,
                Controller = model.Controller,
                Name = model.Name,
                Link = model.Link,
                IconName = model.IconName,
                Category=model.Category               
            };

        }
    }
    
}