using LifeLike.Services.Commons.Models.Config;

namespace LifeLike.Services.Commons.Interfaces;

public interface IConfigService
{
    Task<ConfigModel> Create(CreateConfigModel model);

    Task<ConfigModel> Get(Guid id);

    Task<IList<ConfigModel>> List();

    Task<ConfigModel> Update(Guid id, UpdateConfigModel model);

    Task Delete(Guid id);
}