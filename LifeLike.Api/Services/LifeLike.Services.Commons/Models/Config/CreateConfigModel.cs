using LifeLike.Common.Enums;

namespace LifeLike.Services.Commons.Models.Config;

public class CreateConfigModel
{
    public string Name { get; set; }

    public string Value { get; set; }

    public string DisplayName { get; set; }

    public ConfigType Type { get; set; }

}