using LifeLike.Models.Base;

namespace LifeLike.Models.Category
{
    public class CategoryResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public int Order { get; set; }
    }
}
