using LifeLike.Common.Enums;

namespace LifeLike.Services.Commons.Models.Config;

public class UpdateConfigModel
{
    public string Name { get; set; }
    
    public ConfigType Type { get; set; }
    
    public string Value { get; set; }

    public string DisplayName { get; set; }
}