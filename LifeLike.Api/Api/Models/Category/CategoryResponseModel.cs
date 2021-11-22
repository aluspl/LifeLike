using Api.Models.Base;

namespace Api.Models.Category
{
    public class CategoryResponseModel : BaseResponseModel
    {
        public string Name { get; set; }

        public int Order { get; set; }
    }
}
