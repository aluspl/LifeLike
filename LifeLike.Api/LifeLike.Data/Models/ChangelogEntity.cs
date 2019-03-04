using LifeLike.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LifeLike.Data.Models
{
    public class ChangelogEntity : IEntity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string Link { get; set; }
        public ChangelogEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}