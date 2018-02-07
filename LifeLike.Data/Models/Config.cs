using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class Config
    {
        
        public static string WelcomeVideo = "WelcomeVideo";
        public static string WelcomeText = "WelcomeText";
        public static string RSS1 = "RSS1";
        public static string RSS2 = "RSS2";
        
        
        
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string DisplayName { get; set; }

       
    }
}