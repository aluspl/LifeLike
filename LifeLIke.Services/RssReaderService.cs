using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Services.Model;

namespace LifeLIke.Services
{
    public class RssReaderService : IRssReaderService
    {
	    private readonly IEventLogRepository _logger;

	    public RssReaderService(IEventLogRepository eventLog)
	    {
		    _logger = eventLog;
	    }
	    
        private static DateTime ParseDate(string date)
        {
	        return DateTime.TryParse(date, out var result) ? result : DateTime.MinValue;
        }
    

	/// <summary>
	/// Parses the given <see cref="FeedType"/> and returns a <see cref="IList{T}"/>.
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
			await _logger.AddException(e);
			return new List<RssViewModel>();
		}
		
	}

	/// <summary>
	/// Parses an Atom feed and returns a <see cref="IList{T}"/>.
	/// </summary>
	public virtual async Task<IList<RssViewModel>> ParseAtom(Stream stream)
	{
		try
		{
			XDocument doc = XDocument.Load(stream);
			// Feed/Entry
			var entries = doc.Root.Elements()
				.Where(i => i.Name.LocalName == "entry")
				.Select(item => new RssViewModel
				{
					FeedType = FeedType.Atom,
					Description = item.Elements().First(i => i.Name.LocalName == "content").Value,
					Link = item.Elements().First(i => i.Name.LocalName == "link").Attribute("href")?.Value,
					PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "published").Value),
					Title = item.Elements().First(i => i.Name.LocalName == "title").Value
				});
			return entries.ToList();
		}
		catch(Exception e)
		{
			await _logger.AddException(e);
			return new List<RssViewModel>();

		}
	}

	/// <summary>
	/// Parses an RSS feed and returns a <see cref="IList{T}"/>.
	/// </summary>
	public virtual async Task<IList<RssViewModel>> ParseRss(Stream stream)
	{
		try
		{
			var doc = XDocument.Load(stream);
			// RSS/Channel/item
			var entries = from item in doc.Root?.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
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
		catch(Exception e)
		{
			await _logger.AddException(e);
			return new List<RssViewModel>();
		}
	}

}

	public interface IRssReaderService
	{
		Task<IList<RssViewModel>> Parse(string url, FeedType feedType);
	}
}