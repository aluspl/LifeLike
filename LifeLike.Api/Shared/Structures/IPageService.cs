using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using System.Collections.Generic;

namespace LifeLike.Shared.Structures
{
    public interface IPageService
    {
        IEnumerable<Page> List(PageCategory category);
        Page Get(string id);
        Result Create(Page model, Link link);
        Result Create(Page model);
        Result Delete(string id);
        Result Update(Page model);
        IEnumerable<Page> List();
    }
}