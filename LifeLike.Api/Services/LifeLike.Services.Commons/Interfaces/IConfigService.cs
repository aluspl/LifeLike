using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Config;

namespace LifeLike.Services.Commons.Interfaces
{
    public interface IConfigService
    {
        Task<ConfigReadModel> Create(ConfigWriteModel model);

        Task<ConfigReadModel> Get(Guid id);

        Task<IList<ConfigReadModel>> List();

        Task<ConfigReadModel> Update(ConfigWriteModel model);

        Task Delete(Guid id);
    }
}
