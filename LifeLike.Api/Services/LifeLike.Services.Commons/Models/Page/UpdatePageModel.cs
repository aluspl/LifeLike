namespace LifeLike.Services.Domain.Profiles;

public class UpdatePageModel
{
    public string ShortName { get; set; }

    public string FullName { get; set; }

    public string Summary { get; set; }

    public int Order { get; set; }
}