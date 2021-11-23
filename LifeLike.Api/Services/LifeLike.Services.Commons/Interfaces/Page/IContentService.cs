using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Services.Commons.Interfaces.Page
{
    public interface IContentService
    {
        Task<ContentReadModel> Create(ContentWriteModel model);

        Task<ContentReadModel> Update(Guid id, ContentWriteModel model);

        Task Delete(Guid id);

        Task<IEnumerable<ContentReadModel>> ListByCategory(ContentCategory category);

        Task<IEnumerable<ContentReadModel>> List();
    }
}
