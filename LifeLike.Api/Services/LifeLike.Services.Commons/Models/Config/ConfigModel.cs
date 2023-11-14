using LifeLike.Common.Enums;
using LifeLike.Services.Commons.Models.Base;

namespace LifeLike.Services.Commons.Models.Config;

public class ConfigModel : BaseModel
{
    public string Name { get; set; }

    public string Value { get; set; }

    public string DisplayName { get; set; }

    public ConfigType Type { get; set; }

}