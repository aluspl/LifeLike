using System.Linq;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Models
{
    public class LifeLikeContext : DbContext
    {
        
        public DbSet<LinkDataModel> Links { get; set; }
        public DbSet<ChangelogDataModel> Changelogs { get; set; }
         public DbSet<EventLogDataModel> EventLogs { get; set; }

        public LifeLikeContext(DbContextOptions<LifeLikeContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkDataModel>().ToTable("Links");
            modelBuilder.Entity<ChangelogDataModel>().ToTable("Changelogs");
        }
    }

            public static class DbInitializer
    {
        public static void Initialize(LifeLikeContext context)
        {
            context.Database.EnsureCreated();
            if (context.Links.Any())
            {
                return;   // DB has been seeded
            }
            //Menu
            context.Add(new LinkDataModel()
            {
                        Action = "Index", 
                        Controller = "Video", 
                        Name = "Video Projects", 
                        Category = LinkCategory.Menu
            });
            context.Add(new LinkDataModel()
            {
                        Action = "Index", 
                        Controller = "LifeLike", 
                        Name = "LifeLike: The Game", 
                        Category = LinkCategory.Menu
            });
            context.Add(new LinkDataModel()
            {
                        Action = "About", 
                        Controller = "Home", 
                        Name = "About Me", 
                        Category = LinkCategory.Menu
            });
            // Sidebar
            context.Add(new LinkDataModel() { 
                        Link = "https://github.com/aluspl/", 
                        IconName = "fire", 
                        Name = "Github", Category = LinkCategory.Sidebar});
            context.Add(new LinkDataModel() { 
                        Link = "http://kawowipodroznicy.pl", 
                        IconName = "globe", 
                        Name = "Kawowi Podróżnicy",
                        Category = LinkCategory.Sidebar});            
            context.Add(new LinkDataModel() { 
                        Link = "http://szymonmotyka.pl", 
                        IconName = "pencil", 
                        Name = "Personal Blog",
                        Category = LinkCategory.Sidebar});            
            context.Add(new LinkDataModel() { 
                        Link = "https://www.linkedin.com/in/szymon-motyka-a7440b58/", 
                        IconName = "comment", 
                        Name = "LinkedIn",
                        Category = LinkCategory.Sidebar});
            context.Add(new LinkDataModel() { 
                        Link = "https://www.facebook.com/SzymonMotykapl/", 
                        IconName = "comment", 
                        Name = "Facebook",
                        Category = LinkCategory.Sidebar});
            context.Add(new LinkDataModel() { 
                        Link = "https://www.youtube.com/user/alusvanzuoo", 
                        IconName = "play", 
                        Name = "YT: Szymon Motyka",
                        Category = LinkCategory.Sidebar});
            context.Add(new LinkDataModel() { 
                        Link = "https://www.youtube.com/channel/UC-F1oSvOzczOSLAAsCLBvVA", 
                        IconName = "play", 
                        Name = "YT: Kawowi Podróżnicy",
                        Category = LinkCategory.Sidebar});
                     
            context.SaveChanges();

        }
    }

}