using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Domain.Profiles;
using LifeLike.Services.Domain.Services;

namespace LifeLike.Services.Page;

public class CategoryService : BaseService, ICategoryService
{
    private readonly IRepository<CategoryEntity> _repository;

    public CategoryService(IRepository<CategoryEntity> repository) : base()
    {
        _repository = repository;
    }

    public async Task<CategoryModel> Create(CategoryWriteModel model)
    {
        var item = await _repository.Add(model.Map());
        return item.Map();
    }

    public async Task<IEnumerable<CategoryModel>> List()
    {
        var items = await _repository.GetAll();
        return items.Select(x => x.Map()).ToList();
    }

    public async Task<CategoryModel> Get(Guid id)
    {
        var item = await _repository.Get(o => o.Id == id);
        return item.Map();
    }

    public async Task<CategoryModel> Update(Guid id, CategoryWriteModel model)
    {
        var item = await _repository.Get(o => o.Id == id);
        item = await _repository.Update(item);
        return item.Map();
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(o => o.Id == id);
    }
}