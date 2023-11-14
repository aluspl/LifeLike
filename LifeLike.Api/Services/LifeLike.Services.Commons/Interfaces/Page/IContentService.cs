using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Services.Commons.Interfaces.Page;

public interface IContentService
{
    Task<ContentModel> Create(ContentWriteModel model);

    Task<ContentModel> Update(Guid id, ContentWriteModel model);

    Task Delete(Guid id);

    Task<IEnumerable<ContentModel>> ListByCategory(ContentCategory category);

    Task<IEnumerable<ContentModel>> List();
}