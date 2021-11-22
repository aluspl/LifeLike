using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Models.Link;

namespace LifeLike.Services.Commons.Interfaces
{
    public interface ILinkService
    {
        Task<IEnumerable<LinkReadModel>> List(LinkCategory category);

        Task<LinkReadModel> GetByAction(string action);

        Task Delete(Guid id);

        Task<LinkReadModel> Create(LinkWriteModel link);

        Task<IEnumerable<LinkReadModel>> List();

        Task<LinkReadModel> Update(Guid id, LinkWriteModel model);
    }
}
