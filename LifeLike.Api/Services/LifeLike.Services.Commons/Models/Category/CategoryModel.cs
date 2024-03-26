using LifeLike.Services.Commons.Models.Base;

namespace LifeLike.Services.Commons.Models.Category;

public class CategoryModel : BaseModel
{
    public string Name { get; set; }

    public int Order { get; set; }
}