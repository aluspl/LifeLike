using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Page;

namespace LifeLike.Services.Commons.Interfaces.Page
{
    public interface IPageService : IQueryPageService
    {
        Task<PageReadModel> Create(PageWriteModel model);

        Task Delete(Guid id);

        Task<PageReadModel> Update(Guid id, PageWriteModel model);
    }
}
