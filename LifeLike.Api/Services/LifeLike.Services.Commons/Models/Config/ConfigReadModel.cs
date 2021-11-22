using LifeLike.Services.Commons.Models.Base;

namespace LifeLike.Services.Commons.Models.Config
{
    public class ConfigReadModel : BaseReadModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }

    }
}
