using LifeLike.Services.Commons.Models.Base;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Services.Commons.Models.Page;

public class PageModel : BaseModel
{
    public string ShortName { get; set; }

    public string FullName { get; set; }

    public string Summary { get; set; }

    public int Order { get; set; }

    public ICollection<CategoryModel> Categories { get; set; }

    public ICollection<ContentModel> Contents { get; set; }

    public PhotoModel Image { get; set; }

    public DateTime? Published { get; set; }
}