using System.ComponentModel.DataAnnotations;
using LifeLike.Data.Models.Enums;
using LifeLike.Shared.Models;

namespace LifeLike.Data.Models
{
    public class LinkEntity : Entity
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconName { get; set; }
        public int Order { get; set; }
        public LinkCategory Category { get; set; }
        
    }
}