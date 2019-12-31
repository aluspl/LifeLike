using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using System.Collections.Generic;

namespace LifeLike.Shared.Structures
{
    public interface ILinkService
    {
        IEnumerable<Link> List(LinkCategory category);
        Link Get(string id);
        Result Delete(string shortName);
        Result Create(Link link);
        IEnumerable<Link> List();
        Result Update(Link model);
    }
}