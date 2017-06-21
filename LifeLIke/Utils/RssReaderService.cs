using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using LifeLike.ViewModel;

namespace LifeLIke.Utils
{
    public class RssReaderService : IRssReaderService
    {
	    private readonly IEventLogRepository _eventLog;

	    public RssReaderService(IEventLogRepository eventLog)
	    {
		    _eventLog = eventLog;
	    }
	    
        private static DateTime ParseDate(string date)
        {
            DateTime result;
            return DateTime.TryParse(date, out result) ? result : DateTime.MinValue;
        }
    

	/// <summary>
	/// Parses the given <see cref="FeedType"/> and returns a <see cref="IList&amp;lt;Item&amp;gt;"/>.
	/// </summary>
	/// <returns></returns>
	public async Task<IList<RssViewModel>> Parse(string url, FeedType feedType)
	{
		try
		{
			using (var httpclient = new HttpClient())
			{
				var response = await httpclient.GetAsync(url);

				var feed = await response.Content.ReadAsStreamAsync();

				switch (feedType)
				{
					case FeedType.RSS:
						return await ParseRss(feed);
					case FeedType.Atom:
						return await ParseAtom(feed);
					default:
						throw new NotSupportedException(string.Format("{0} is not supported", feedType.ToString()));
				}
			}
		}
		catch (Exception e)
		{
			_eventLog.AddExceptionLog(e);
			return new List<RssViewModel>();
		}
		
	}

	/// <summary>
	/// Parses an Atom feed and returns a <see cref="IList&amp;lt;Item&amp;gt;"/>.
	/// </summary>
	public virtual async Task<IList<RssViewModel>> ParseAtom(Stream stream)
	{
		try
		{
			XDocument doc = XDocument.Load(stream);
			// Feed/Entry
			var entries = from item in doc.Root.Elements().Where(i => i.Name.LocalName == "entry")
						  select new RssViewModel
						  {
							  FeedType = FeedType.Atom,
							  Description = item.Elements().First(i => i.Name.LocalName == "content").Value,
							  Link = item.Elements().First(i => i.Name.LocalName == "link").Attribute("href").Value,
							  PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "published").Value),
							  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
						  };
			return entries.ToList();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// Parses an RSS feed and returns a <see cref="IList&amp;lt;Item&amp;gt;"/>.
	/// </summary>
	public virtual async Task<IList<RssViewModel>> ParseRss(Stream stream)
	{
		try
		{
			XDocument doc = XDocument.Load(stream);
			// RSS/Channel/item
			var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
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
		catch
		{
			throw;
		}
	}

}

	public interface IRssReaderService
	{
		Task<IList<RssViewModel>> Parse(string url, FeedType feedType);
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