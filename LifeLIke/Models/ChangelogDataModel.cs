using System;
using LifeLike.Models.Enums;

namespace LifeLike.Models
{
    public class ChangelogDataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string Link { get; set; }

    }
}