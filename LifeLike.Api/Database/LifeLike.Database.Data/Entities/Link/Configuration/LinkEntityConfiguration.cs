#region Usings

using LifeLike.Common.Enums;
using LifeLike.Database.Data.Entities.Base.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace LifeLike.Database.Data.Entities.Link.Configuration;

public class LinkEntityConfiguration : BaseEntityConfiguration<LinkEntity>
{
    public override void Configure(EntityTypeBuilder<LinkEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(q => q.Category)
            .HasConversion(
                v => v.ToString(),
                v => (LinkCategory)Enum.Parse(typeof(LinkCategory), v));
    }
}