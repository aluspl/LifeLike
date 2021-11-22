#region Usings

using System.Linq;
using System.Threading.Tasks;
using LifeLike.Common.Config;
using LifeLike.Common.Enums;
using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Entities.Link;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

#endregion

namespace LifeLike.Database.Data
{
    public class DatabaseInitializer
    {
        #region Private fields

        private readonly EFContext _context;
        private readonly SeedConfigs _seedConfigs;

        #endregion

        #region Constructor(s)

        public DatabaseInitializer(
            EFContext context,
            IOptions<SeedConfigs> configs)
        {
            _context = context;
            _seedConfigs = configs.Value;
        }

        #endregion

        #region Public methods

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();
            await _context.SaveChangesAsync();
            await Initialize();
        }

        #endregion

        #region Private methods

        public async Task Initialize()
        {
            if (!_context.Links.Any())
            {
                await SetupLinks();
            }

            if (!_context.Categories.Any())
            {
                await SetupLinks();
            }

            if (!_context.Configs.Any())
            {
                await SetupConfigs();
            }

            _context.SaveChanges();
        }

        private async Task SetupConfigs()
        {
            if (_seedConfigs.Configs.Any())
            {
                foreach (var config in _seedConfigs.Configs)
                {
                    await _context.AddAsync(new ConfigEntity
                    {
                        Name = config.Name,
                        DisplayName = config.DisplayName,
                        Value = config.Value,
                        Type = config.Type,
                    });
                }
            }
        }

        private async Task SetupLinks()
        {
            await _context.AddAsync(new LinkEntity
            {
                Action = "",
                Controller = "Posts",
                Name = "News",
                IconName = "newspaper",

                Category = LinkCategory.Menu
            });
            await _context.AddAsync(new LinkEntity
            {
                Action = "",
                Controller = "Albums",
                Name = "Albums",
                IconName = "camera-retro",
                Category = LinkCategory.Menu
            });
            await _context.AddAsync(new LinkEntity
            {
                Action = "",
                Controller = "Videos",
                Name = "VIDEOS",
                IconName = "film",
                Category = LinkCategory.Menu
            });
            await _context.AddAsync(new LinkEntity
            {
                Action = "",
                Controller = "Pages",
                Name = "PROJECTS",
                IconName = "code",
                Category = LinkCategory.Menu
            });
            await _context.AddAsync(new LinkEntity
            {
                Action = "",
                Controller = "Logs",
                Name = "Logs",
                IconName = "book",
                Category = LinkCategory.Menu
            });
            await _context.AddAsync(new LinkEntity
            {
                Action = "Contact",
                Controller = "Page",
                Name = "CONTACT",
                IconName = "at",
                Category = LinkCategory.Menu
            });
            // Sidebar
            await _context.AddAsync(new LinkEntity
            {
                Url = "https://github.com/aluspl/",
                IconName = "fire",
                Name = "Github",
                Category = LinkCategory.Sidebar
            });
            await _context.AddAsync(new LinkEntity
            {
                Url = "https://kawowipodroznicy.pl",
                IconName = "globe",
                Name = "Kawowi Podróżnicy",
                Category = LinkCategory.Sidebar
            });
            await _context.AddAsync(new LinkEntity
            {
                Url = "https://szymonmotyka.pl",
                IconName = "pencil",
                Name = "Personal Blog",
                Category = LinkCategory.Sidebar
            });
            await _context.AddAsync(new LinkEntity
            {
                Url = "https://www.linkedin.com/in/szymon-motyka-a7440b58/",
                IconName = "comment",
                Name = "LinkedIn",
                Category = LinkCategory.Sidebar
            });
            await _context.AddAsync(new LinkEntity
            {
                Url = "https://www.facebook.com/SzymonMotykapl/",
                IconName = "comment",
                Name = "Facebook",
                Category = LinkCategory.Sidebar
            });
            await _context.AddAsync(new LinkEntity
            {
                Url = "https://www.youtube.com/user/alusvanzuoo",
                IconName = "play",
                Name = "YT: Szymon Motyka",
                Category = LinkCategory.Sidebar
            });
            await _context.AddAsync(new LinkEntity
            {
                Url = "https://www.youtube.com/channel/UC-F1oSvOzczOSLAAsCLBvVA",
                IconName = "play",
                Name = "YT: Kawowi Podróżnicy",
                Category = LinkCategory.Sidebar
            });
        }

        #endregion
    }
}
