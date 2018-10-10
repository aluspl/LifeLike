using System.Linq;
using LifeLike.Data.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Data.Models
{
    public class PortalContext : IdentityDbContext<User>
    {
        public DbSet<LinkEntity> Links { get; set; }
        public DbSet<ChangelogEntity> Changelogs { get; set; }
        public DbSet<EventLogEntity> EventLogs { get; set; }
        public DbSet<GalleryEntity> Galleries { get; set; }

        public DbSet<PageEntity> Pages { get; set; }

        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<ConfigEntity> Configs { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }

        public DbSet<StatisticEntity> Stats { get; set; }

        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
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
                context.Pages.Add(new PageEntity
                    {
                        ShortName = "contact",
                        Category = PageCategory.Page,
                        FullName = "Contact Me",
                        PageOrder = 0,
                        Content = "Phone: 600836095"
                    }
                );
            }

            context.SaveChanges();
        }

        private static void SetupConfigs(PortalContext context)
        {
            context.Add(new ConfigEntity
            {
                Name = ConfigEntity.WelcomeVideo,
                DisplayName = "Welcome Video",
                Value = "ISTWYjAhEHc", Type = ConfigType.Video
                
            });
            context.Add(new ConfigEntity
            {
                Name = ConfigEntity.WelcomeText,
                DisplayName = "HI!",
                Value = "Hi on my page , it is pure now, but it is great CMS :) ... it is gonna to be great cms", Type = ConfigType.Text
            });
            context.Add(new ConfigEntity
            {
                Name = ConfigEntity.Rss1,
                DisplayName = "First RSS Url",
                Value = "http://kawowipodroznicy.pl/feed/", Type = ConfigType.RSS
            });
            context.Add(new ConfigEntity
            {
                Name = ConfigEntity.Rss2,
                DisplayName = "Second RSS Url",
                Value = "http://szymonmotyka.pl/feed/", Type = ConfigType.RSS
            });
        }

        private static void SetupLinks(PortalContext context)        
        {         
            context.Add(new LinkEntity          
                {
                    Action = "",
                    Controller = "Posts",
                    Name = "News",
                    IconName = "newspaper",

                    Category = LinkCategory.Menu
                });
            context.Add(new LinkEntity          
                {
                    Action = "",
                    Controller = "Albums",
                    Name = "Albums",
                    IconName = "camera-retro",
                    Category = LinkCategory.Menu
                });
            context.Add(new LinkEntity
                {
                    Action = "",
                    Controller = "Videos",
                    Name = "VIDEOS",
                    IconName = "film",
                    Category = LinkCategory.Menu
                });
            context.Add(new LinkEntity
                {
                    Action = "",
                    Controller = "Pages",
                    Name = "PROJECTS",
                    IconName = "code",
                    Category = LinkCategory.Menu
                });            
            context.Add(new LinkEntity
            {
                Action = "",
                Controller = "Logs",
                Name = "Logs",
                IconName = "book",
                Category = LinkCategory.Menu
            });
            context.Add(new LinkEntity
            {
                Action = "Contact",
                Controller = "Page",
                Name = "CONTACT",
                IconName = "at",
                Category = LinkCategory.Menu
            });                             
            // Sidebar
            context.Add(new LinkEntity
            {
                Url = "https://github.com/aluspl/",
                IconName = "fire",
                Name = "Github",
                Category = LinkCategory.Sidebar
            });
            context.Add(new LinkEntity
            {
                Url = "http://kawowipodroznicy.pl",
                IconName = "globe",
                Name = "Kawowi Podróżnicy",
                Category = LinkCategory.Sidebar
            });
            context.Add(new LinkEntity
            {
                Url = "http://szymonmotyka.pl",
                IconName = "pencil",
                Name = "Personal Blog",
                Category = LinkCategory.Sidebar
            });
            context.Add(new LinkEntity
            {
                Url = "https://www.linkedin.com/in/szymon-motyka-a7440b58/",
                IconName = "comment",
                Name = "LinkedIn",
                Category = LinkCategory.Sidebar
            });
            context.Add(new LinkEntity
            {
                Url = "https://www.facebook.com/SzymonMotykapl/",
                IconName = "comment",
                Name = "Facebook",
                Category = LinkCategory.Sidebar
            });
            context.Add(new LinkEntity
            {
                Url = "https://www.youtube.com/user/alusvanzuoo",
                IconName = "play",
                Name = "YT: Szymon Motyka",
                Category = LinkCategory.Sidebar
            });
            context.Add(new LinkEntity
            {
                Url = "https://www.youtube.com/channel/UC-F1oSvOzczOSLAAsCLBvVA",
                IconName = "play",
                Name = "YT: Kawowi Podróżnicy",
                Category = LinkCategory.Sidebar
            });
        }
    }
}