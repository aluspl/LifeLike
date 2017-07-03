using System.ComponentModel.DataAnnotations;

namespace LifeLike.ViewModel
{
    public class ConfigViewModel
    {
        [Key]       
        public string Name { get; set; }

        public string Value { get; set; }
        public string DisplayName { get; set; }
       
    }
}