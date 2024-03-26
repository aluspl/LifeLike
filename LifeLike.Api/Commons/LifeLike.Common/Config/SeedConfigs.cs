namespace LifeLike.Common.Config;

public class SeedConfigs
{
    public SeedConfigs()
    {
        Links = new List<SeedLink>();
        Categories = new List<SeedCategory>();
        Configs = new List<SeedConfig>();
    }
    public ICollection<SeedLink> Links { get; set; }

    public ICollection<SeedCategory> Categories { get; set; }

    public ICollection<SeedConfig> Configs { get; set; }
}