using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using LifeLike.ViewModel;

namespace LifeLIke.Utils
{
    public class RssReader
    {     
        /// <summary>
        /// Parses an RSS feed and returns a <see cref="IList&amp;lt;Item&amp;gt;"/>.
        /// </summary>
        public static async Task<IList<RssViewModel>> ParseRss(string url)
        {
            try
            {
                using (var httpclient = new HttpClient())
                {
                    var response = await httpclient.GetAsync(url);

                    var doc = XDocument.Load(await response.Content.ReadAsStreamAsync());
                    // RSS/Channel/item
                    var entries = from item in doc.Root?.Descendants().First(i => i.Name.LocalName == "channel")
                            .Elements()
                            .Where(i => i.Name.LocalName == "item")
                        select new RssViewModel
                        {
                            FeedType = FeedType.RSS,
                            Description = item.Elements().First(i => i.Name.LocalName == "description").Value,
                            Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                            PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                            Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                        };
                    return entries.ToList();
                }
            }
            catch(Exception e)
            {
                LogUtils.AddExceptionLog(e);
                return new List<RssViewModel>();
            }
        }
        private static DateTime ParseDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date, out result))
                return result;
            else
                return DateTime.MinValue;
        }
    }

    /// <summary>
    /// Represents the XML format of a feed.
    /// </summary>
    public enum FeedType
    {
        /// <summary>
        /// Really Simple Syndication format.
        /// </summary>
        RSS,

        /// <summary>
        /// Atom Syndication format.
        /// </summary>
        Atom
    }
}