using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Entities.Link;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Entities.Photo;
using LifeLike.Database.Data.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Database.Data;

public class EfContext : IdentityDbContext<UserEntity>
{
    public DbSet<LinkEntity> Links { get; set; }

    public DbSet<PageEntity> Pages { get; set; }

    public DbSet<ImageEntity> Photos { get; set; }
    public DbSet<ConfigEntity> Configs { get; set; }

    public DbSet<ContentEntity> Contents { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    public EfContext(DbContextOptions<EfContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Data).Assembly);
    }
}