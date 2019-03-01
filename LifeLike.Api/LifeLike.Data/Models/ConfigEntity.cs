using System.ComponentModel.DataAnnotations;
using LifeLike.Data.Models.Enums;
using LifeLike.Shared.Models;

namespace LifeLike.Data.Models
{
    public class ConfigEntity : Entity
    {
        public const string WelcomeVideo = "WelcomeVideo";
        public const string WelcomeText = "WelcomeText";
        public const string Rss1 = "RSS1";
        public const string Rss2 = "RSS2";

        public string Name { get; set; }
        public string Value { get; set; }
        public string DisplayName { get; set; }
        public ConfigType Type { get; set; }
       
    }
}