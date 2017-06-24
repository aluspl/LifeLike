using System.Linq;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Models
{
    public class PortalContext : DbContext
    {
                private readonly DbContextOptions<PortalContext> _options;

         public DbSet<Link> Links { get; set; }
        public DbSet<Changelog> Changelogs { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
                
        public DbSet<Photo> Photos { get; set; }
                public DbSet<Config> Configs { get; set; }

        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
                    _options = options;
        }    
    }

    public static class DbInitializer
    {
        public static void Initialize(PortalContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Links.Any())
            {
                SetupLinks(context);
            }
            if (!context.Configs.Any())
            {
                SetupConfigs(context);
            }
                     
            context.SaveChanges();

        }

        private static void SetupConfigs(PortalContext context)
        {
            context.Add(new Config()
            {
              Name="CurrentMovie", Value = "Qi5tp0eZHt8"
            });
            
        }

        private static void SetupLinks(PortalContext context)
        {
            //Menu
            context.Add(new Link()
            {
                Action = "Index",
                Controller = "Video",
                Name = "Video Projects",
                Category = LinkCategory.Menu
            });
            context.Add(new Link()
            {
                Action = "Index",
                Controller = "LifeLike",
                Name = "LifeLike: The Game",
                Category = LinkCategory.Menu
            });
            context.Add(new Link()
            {
                Action = "About",
                Controller = "Home",
                Name = "About Me",
                Category = LinkCategory.Menu
            });
            // Sidebar
            context.Add(new Link()
            {
                Url = "https://github.com/aluspl/",
                IconName = "fire",
                Name = "Github",
                Category = LinkCategory.Sidebar
            });
            context.Add(new Link()
            {
                Url = "http://kawowipodroznicy.pl",
                IconName = "globe",
                Name = "Kawowi Podróżnicy",
                Category = LinkCategory.Sidebar
            });
            context.Add(new Link()
            {
                Url = "http://szymonmotyka.pl",
                IconName = "pencil",
                Name = "Personal Blog",
                Category = LinkCategory.Sidebar
            });
            context.Add(new Link()
            {
                Url = "https://www.linkedin.com/in/szymon-motyka-a7440b58/",
                IconName = "comment",
                Name = "LinkedIn",
                Category = LinkCategory.Sidebar
            });
            context.Add(new Link()
            {
                Url = "https://www.facebook.com/SzymonMotykapl/",
                IconName = "comment",
                Name = "Facebook",
                Category = LinkCategory.Sidebar
            });
            context.Add(new Link()
            {
                Url = "https://www.youtube.com/user/alusvanzuoo",
                IconName = "play",
                Name = "YT: Szymon Motyka",
                Category = LinkCategory.Sidebar
            });
            context.Add(new Link()
            {
                Url = "https://www.youtube.com/channel/UC-F1oSvOzczOSLAAsCLBvVA",
                IconName = "play",
                Name = "YT: Kawowi Podróżnicy",
                Category = LinkCategory.Sidebar
            });
        }
    }

}