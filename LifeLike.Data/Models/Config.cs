using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class Config
    {
        public const string WelcomeVideo = "WelcomeVideo";
        public const string WelcomeText = "WelcomeText";
        public const string Rss1 = "RSS1";
        public const string Rss2 = "RSS2";


        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string DisplayName { get; set; }

       
    }
}