using System.ComponentModel.DataAnnotations;

namespace LifeLike.Shared.Model
{
    public class Config
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }
       
    }
}