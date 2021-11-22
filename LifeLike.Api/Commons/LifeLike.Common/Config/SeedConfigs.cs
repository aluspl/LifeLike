using System.Collections.Generic;

namespace LifeLike.Common.Config
{
    public class SeedConfigs
    {
        public ICollection<SeedLink> Links { get; set; }

        public ICollection<SeedCategory> Categories { get; set; }

        public ICollection<SeedConfig> Configs { get; set; }
    }
}
