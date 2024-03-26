#region Usings

#endregion

using LifeLike.Services.Domain;
using Lifelike.Services.IdentityService;
using LifeLike.Services.Media;
using LifeLike.Services.Page;

namespace LifeLIke.Services.All;

public class ServicesAssembly
{
    public IdentityService IdentityService { get; }

    public MediaService MediaService { get; }

    public PageService PageService { get; }

    public Domain Domain { get; set; }
}