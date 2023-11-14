using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Models.Link;

namespace LifeLike.Services.Commons.Interfaces;

public interface ILinkService
{
    Task<IEnumerable<LinkModel>> List(LinkCategory category);

    Task<LinkModel> GetByAction(string action);

    Task Delete(Guid id);

    Task<LinkModel> Create(CreateLinkModel createLink);

    Task<IEnumerable<LinkModel>> List();

    Task<LinkModel> Update(Guid id, CreateLinkModel model);
}