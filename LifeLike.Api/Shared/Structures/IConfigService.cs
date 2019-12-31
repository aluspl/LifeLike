using System.Collections.Generic;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;

namespace LifeLike.Shared.Structures
{
    public interface IConfigService 
    {
        Result Create(Config model);
        Config Get(string id);
        IList<Config> List();
        Result Update(Config model);
    }
}