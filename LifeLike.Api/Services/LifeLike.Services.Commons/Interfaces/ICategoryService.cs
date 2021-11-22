using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Category;

namespace LifeLike.Services.Commons.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryReadModel> Create(CategoryWriteModel model);

        Task<CategoryReadModel> Get(Guid id);

        Task<IEnumerable<CategoryReadModel>> List();

        Task<CategoryReadModel> Update(Guid id, CategoryWriteModel model);

        Task Delete(Guid id);
    }
}
