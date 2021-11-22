using LifeLike.Common.Enums;

namespace LifeLike.Database.Data.Entities
{
    public class StatisticEntity : BaseEntity
    {
        public  string Action { get; set; }
        public  string Controller { get; set; }
        public  string Parameter { get; set; }
        public StatisticType Type { get; set; }
    }
}
