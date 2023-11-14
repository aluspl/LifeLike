using LifeLike.Common.Enums;
using LifeLike.Database.Data.Entities.Page;

namespace LifeLike.Database.Data.Entities.Link;

public class LinkEntity : BaseEntity
{
    public string Controller { get; set; }

    public string Action { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public string IconName { get; set; }

    public int Order { get; set; }

    public LinkCategory Category { get; set; }

    public string IsExternal { get; set; }

    public PageEntity Page { get; set; }
}