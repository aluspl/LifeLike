using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Services.Commons.Interfaces;
using LifeLike.Services.Commons.Models.Config;
using LifeLike.Services.Domain.Profiles;
using Microsoft.Extensions.Logging;

namespace LifeLike.Services.Domain.Services;

public class ConfigService : BaseService, IConfigService
{
    private readonly IRepository<ConfigEntity> _configRepository;
    private readonly ILogger<ConfigService> _log;

    public ConfigService(IRepository<ConfigEntity> configRepository,
        ILogger<ConfigService> logger)
        : base()
    {
        _configRepository = configRepository;
        _log = logger;
    }

    public async Task<ConfigModel> Create(CreateConfigModel model)
    {
        var entity = new ConfigEntity()
        {
            Name    = model.Name,
            DisplayName = model.DisplayName,
            Value = model.Value,
            Type = model.Type,
        };
        var configEntity = await _configRepository.Add(entity);
        return configEntity.Map();
    }

    public async Task<ConfigModel> Get(Guid id)
    {
        var item = await _configRepository.Get(p => p.Id == id);
        return item.Map();
    }

    public async Task<ConfigModel> Update(Guid id, UpdateConfigModel model)
    {
        var item = await _configRepository.Get(p => p.Id == id);
        item = await _configRepository.Update(item);
        return item.Map();
    }

    public async Task Delete(Guid id)
    {
        await _configRepository.Delete(p => p.Id == id);
    }

    public async Task<IList<ConfigModel>> List()
    {
        var items = await _configRepository.GetAll();
        return items.Select(x => x.Map()).ToList();
    }
}