#region Usings

using LifeLike.Database.Data.Entities.Base.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace LifeLike.Database.Data.Entities.Photo.Configuration
{
    public class PhotoEntityConfiguration : BaseEntityConfiguration<PhotoEntity>
    {
        public override void Configure(EntityTypeBuilder<PhotoEntity> builder)
        {
            base.Configure(builder);

            builder
                .Property(c => c.Filename)
                .IsRequired();
        }
    }
}
