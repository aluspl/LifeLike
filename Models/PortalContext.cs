using System.Linq;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Models
{
    public class PortalContext : IdentityDbContext<User>
    {
        private readonly DbContextOptions<PortalContext> _options;

        public DbSet<Link> Links { get; set; }
        public DbSet<Changelog> Changelogs { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        
        public DbSet<Page> Pages { get; set; }
        
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
            if (!context.Pages.Any())
            {
                context.Pages.Add(new Page {
                    ShortName = "Test", 
                    Category = PageCategory.Page, 
                    FullName  = "Test of this", 
                    PageOrder = 0, Content = "Lorem ipsim"}
                );
            }
            
            context.SaveChanges();

        }

        private static void SetupConfigs(PortalContext context)
        {
            context.Add(new Config()
            {
              Name="WelcomeVideo", DisplayName="Welcome Video", Value = "Qi5tp0eZHt8"
            });
            context.Add(new Config()
            {
                Name="WelcomeText", DisplayName = "Welcome Text", Value = "Hello on Main Page"
            });
            context.Add(new Config()
            {
                Name="RSS1", DisplayName = "First RSS Url", Value = "http://kawowipodroznicy.pl/feed/"
            });
            context.Add(new Config()
            {
                Name="RSS2", DisplayName = "First RSS Url", Value = "http://szymonmotyka.pl/feed/"
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