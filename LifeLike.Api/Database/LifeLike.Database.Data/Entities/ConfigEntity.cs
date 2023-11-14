using LifeLike.Common.Enums;

namespace LifeLike.Database.Data.Entities;

public class ConfigEntity : BaseEntity
{
    public string Name { get; set; }

    public string Value { get; set; }

    public string DisplayName { get; set; }

    public ConfigType Type { get; set; }

}