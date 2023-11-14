namespace LifeLike.Services.Commons.Models.Page;

public class CreatePageModel
{
    public string ShortName { get; set; }

    public string FullName { get; set; }

    public string Summary { get; set; }

    public int Order { get; set; }
}