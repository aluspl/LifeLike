#region Usings

using LifeLike.Database.Data.Entities.Base.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace LifeLike.Database.Data.Entities.Page.Configuration;

public class PageEntityConfiguration : BaseEntityConfiguration<PageEntity>
{
    public override void Configure(EntityTypeBuilder<PageEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(q => q.Shortname)
            .IsRequired();

        builder
            .HasMany(c => c.Categories)
            .WithMany(c => c.Pages);

        builder
            .HasMany(c => c.Contents)
            .WithOne(c => c.Page)
            .HasForeignKey(c => c.PageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(c => c.Link)
            .WithOne(c => c.Page)
            .HasForeignKey<PageEntity>(c => c.LinkId);

        builder
            .HasOne(c => c.Image)
            .WithMany(c => c.Pages)
            .HasForeignKey(c => c.ImageId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}