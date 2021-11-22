using LifeLike.Services.Commons.Models.Base;

namespace LifeLike.Services.Commons.Models.Category
{
    public class CategoryReadModel : BaseReadModel
    {
        public string Name { get; set; }

        public int Order { get; set; }
    }
}
