using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LifeLike.Utils
{
    public class HtmlUtils
    {
        public static IEnumerable<string> glypgicons = new List<string>()
        {
            "glass",
            "music",
            "search",
            "envelope",
            "heart",
            "star",
            "star-empty",
            "user",
            "film",
            "th-large",
            "th",
            "th-list",
            "ok",
            "remove",
            "zoom-in",
            "zoom-out",
            "off",
            "signal",
            "cog",
            "trash",
            "home",
            "file",
            "time",
            "road",
            "download-alt",
            "download",
            "upload",
            "inbox",
            "play-circle",
            "repeat",
            "refresh",
            "list-alt",
            "lock",
            "flag",
            "headphones",
            "volume-off",
            "volume-down",
            "volume-up",
            "qrcode",
            "barcode",
            "tag",
            "tags",
            "book",
            "bookmark",
            "print",
            "camera",
            "font",
            "bold",
            "italic",
            "text-height",
            "text-width",
            "align-left",
            "align-center",
            "align-right",
            "align-justify",
            "list",
            "indent-left",
            "indent-right",
            "facetime-video",
            "picture",
            "pencil",
            "map-marker",
            "adjust",
            "tint",
            "edit",
            "share",
            "check",
            "move",
            "step-backward",
            "fast-backward",
            "backward",
            "play",
            "pause",
            "stop",
            "forward",
            "fast-forward",
            "step-forward",
            "eject",
            "chevron-left",
            "chevron-right",
            "plus-sign",
            "minus-sign",
            "remove-sign",
            "ok-sign",
            "question-sign",
            "info-sign",
            "screenshot",
            "remove-circle",
            "ok-circle",
            "ban-circle",
            "arrow-left",
            "arrow-right",
            "arrow-up",
            "arrow-down",
            "share-alt",
            "resize-full",
            "resize-small",
            "plus",
            "minus",
            "asterisk",
            "exclamation-sign",
            "gift",
            "leaf",
            "fire",
            "eye-open",
            "eye-close",
            "warning-sign",
            "plane",
            "calendar",
            "random",
            "comment",
            "magnet",
            "chevron-up",
            "chevron-down",
            "retweet",
            "shopping-cart",
            "folder-close",
            "folder-open",
            "resize-vertical",
            "resize-horizontal",
            "hdd",
            "bullhorn",
            "bell",
            "certificate",
            "thumbs-up",
            "thumbs-down",
            "hand-right",
            "hand-left",
            "hand-up",
            "hand-down",
            "circle-arrow-right",
            "circle-arrow-left",
            "circle-arrow-up",
            "circle-arrow-down",
            "globe",
            "wrench",
            "tasks",
            "filter",
            "briefcase",
            "fullscreen",
            "dashboard",
            "paperclip",
            "heart-empty",
            "link",
            "phone",
            "pushpin",
            "euro",
            "usd",
            "gbp",
            "sort",
            "sort-by-alphabet",
            "sort-by-alphabet-alt",
            "sort-by-order",
            "sort-by-order-alt",
            "sort-by-attributes",
            "sort-by-attributes-alt",
            "unchecked",
            "expand",
            "collapse",
            "collapse-top"
        };
        public static string GenerateYoutube(LinkViewModel videoLink)
        {
            var format = string.Format("<div class='embed-responsive embed-responsive-16by9'>"
                                       +                         "<h2>{0}</h2>"+                                   
                                       "<iframe width='560' height='315' src='https://www.youtube.com/embed/{1}' " +
                                       "?rel'0' frameborder='0' allowfullscreen></iframe>" + 
                                       "</div>", videoLink.Name, videoLink.Link);
            return format;
        }
        public static string GenerateIcon(string icon)
        {
            var format = string.Format($"<span class='glyphicon glyphicon-{icon}' aria-hidden='true'> </span> ");
            return format;
        }

        public static IEnumerable<SelectListItem> CategoryList
        {
            get
            {
                return Enum.GetValues(typeof(LinkCategory))
                    .Cast<int>()
                    .Select(e =>
                        new SelectListItem {Value = e.ToString(), Text = Enum.GetName(typeof(LinkCategory), e)});
            }
        }
        public static IEnumerable<SelectListItem> IconList
        {
            get { return glypgicons.Select(p => new SelectListItem {Value = p, Text = p}); }
            
        }

        public static IEnumerable<SelectListItem> PageCategoryList   
        {
            get
            {
                return Enum.GetValues(typeof(PageCategory))
                    .Cast<int>()
                    .Select(e =>
                        new SelectListItem {Value = e.ToString(), Text = Enum.GetName(typeof(PageCategory), e)});
            }
        }
    }
}