using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Web.Utils;

namespace LifeLike.Web.ViewModel
{
    public class LinkViewModel
    {
        public long Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        
        public string Name { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public string IconName { get; set; }

    //    public string YoutubeID => GetID();

//        private string GetID()
//        {
//            if (string.IsNullOrEmpty(Link)) return null;
//            return !HtmlUtils.TryParseYoutubeLink(Link, out var value) ? null : value;
//        }

        public LinkCategory Category { get; set; }
        public bool IsLink => (!string.IsNullOrEmpty(Link) && string.IsNullOrEmpty(Controller));

        public string YoutubeID { get; private set; }

        public static Link Get(LinkViewModel model)
        {
            return new Link
            {
                Id=model.Id,
                Action = model.Action,
                Controller = model.Controller,
                Order=model.Order,
                Name = model.Name,
                Url = model.Link,
                IconName = model.IconName,
                Category=model.Category               
            };

        }
        public static LinkViewModel Get(Link model)
        {
            return new LinkViewModel
            {
                Id=model.Id,
                Action = model.Action == "Index" ? string.Empty : model.Action,
                Controller = model.Controller,
                Order=model.Order,
                Name = model.Name,
                Link = model.Url,
                IconName = model.IconName,
                Category=model.Category               
            };

        }
         public static LinkViewModel GetYoutube(Link model)
        {
            return new LinkViewModel
            {
                Id=model.Id,
                Action = model.Action == "Index" ? string.Empty : model.Action,
                Controller = model.Controller,
                Order=model.Order,
                Name = model.Name,
                Link = model.Url,
                YoutubeID = HtmlUtils.GetYoutubeId(model.Url),
                IconName = model.IconName,
                Category=model.Category               
            };

        }
    }
    
}