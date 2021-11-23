using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Page;

namespace LifeLike.Services.Commons.Interfaces.Page
{
    public interface IQueryPageService
    {
        Task<IEnumerable<PageReadModel>> ListByCategory(Guid categoryId);

        Task<PageReadModel> Get(Guid id);

        Task<PageReadModel> Get(string shortName);

        Task<IEnumerable<PageReadModel>> List();
    }
}
