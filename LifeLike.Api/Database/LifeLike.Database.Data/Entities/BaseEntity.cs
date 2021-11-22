using System;
using LifeLike.Database.Data.Interfaces;

namespace LifeLike.Database.Data.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
