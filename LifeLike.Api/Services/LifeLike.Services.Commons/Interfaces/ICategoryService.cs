using LifeLike.Services.Commons.Models.Category;

namespace LifeLike.Services.Commons.Interfaces;

public interface ICategoryService
{
    Task<CategoryModel> Create(CategoryWriteModel model);

    Task<CategoryModel> Get(Guid id);

    Task<IEnumerable<CategoryModel>> List();

    Task<CategoryModel> Update(Guid id, CategoryWriteModel model);

    Task Delete(Guid id);
}