using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Page;

namespace LifeLike.Services.Commons.Interfaces
{
    public interface IPageService
    {
        Task<IEnumerable<PageReadModel>> ListByCategory(Guid categoryId);

        Task<PageReadModel> Get(Guid id);

        Task<PageReadModel> Get(string shortName);

        Task<PageReadModel> Create(PageWriteModel model);

        Task Delete(Guid id);

        Task<PageReadModel> Update(Guid id, PageWriteModel model);

        Task<IEnumerable<PageReadModel>> List();
    }
}
