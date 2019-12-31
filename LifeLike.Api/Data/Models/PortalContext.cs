using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Data.Models
{
    public class PortalContext : IdentityDbContext<User>
    {
        public DbSet<LinkEntity> Links { get; set; }
        public DbSet<ChangelogEntity> Changelogs { get; set; }
        public DbSet<EventLogEntity> EventLogs { get; set; }
        public DbSet<PageEntity> Pages { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<ConfigEntity> Configs { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }
        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}