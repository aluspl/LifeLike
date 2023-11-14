using LifeLike.Common.Enums;

namespace LifeLike.Services.Commons.Models.Link;

public class CreateLinkModel
{
    public string Controller { get; set; }

    public string Action { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public int Order { get; set; }

    public string IconName { get; set; }

    public LinkCategory Category { get; set; }
 
    public string IsExternal { get; set; }
}