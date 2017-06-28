using System.ComponentModel.DataAnnotations;

namespace LifeLike.Models
{
    public class Config
    {
        [Key]       
        public string Name { get; set; }

        public string Value { get; set; }
        public string DisplayName { get; set; }
    }
}