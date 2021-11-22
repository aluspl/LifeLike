#region Usings

using System;
using LifeLike.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace LifeLike.Database.Data.Entities.Page.Configuration
{
    public class ContentEntityConfiguration : IEntityTypeConfiguration<ContentEntity>
    {
        #region Build Company

        public void Configure(EntityTypeBuilder<ContentEntity> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .ToTable(nameof(ContentEntity).Replace("Entity", string.Empty, System.StringComparison.InvariantCultureIgnoreCase));

            builder
                .Property(entity => entity.Created)
                .HasDefaultValueSql("getutcdate()");

            builder
                .Property(q => q.Category)
                .HasConversion(
                    v => v.ToString(),
                    v => (ContentCategory)Enum.Parse(typeof(ContentCategory), v));
        }

        #endregion
    }
}
