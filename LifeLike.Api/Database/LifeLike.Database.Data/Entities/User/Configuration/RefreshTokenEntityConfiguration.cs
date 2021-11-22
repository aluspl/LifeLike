#region Usings

using LifeLike.Database.Data.Entities.Base.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace LifeLike.Database.Data.Entities.User.Configuration
{
    public class RefreshTokenEntityConfiguration : BaseEntityConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
