#region Usings

using LifeLike.Database.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace LifeLike.Database.Data.Entities.Base.Configuration;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity, IBaseEntity
{
    #region Build Base

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .ToTable(typeof(T).Name.Replace("Entity", string.Empty, System.StringComparison.InvariantCultureIgnoreCase));

        builder
            .Property(entity => entity.Created)
            .HasDefaultValueSql("getutcdate()");
    }

    #endregion
}