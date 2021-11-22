#region Usings

using LifeLike.Database.Data.Entities.Base.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace LifeLike.Database.Data.Entities.Page.Configuration
{
    public class CategoryEntityConfiguration : BaseEntityConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            base.Configure(builder);

            builder
                .Property(q => q.Name)
                .IsRequired();

            builder
                .Property(c => c.Order)
                .IsRequired()
                .HasDefaultValue(0);

            builder
                .HasMany(c => c.Pages)
                .WithMany(c => c.Categories);
        }
    }
}
