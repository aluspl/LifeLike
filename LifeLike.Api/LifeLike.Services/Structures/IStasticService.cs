using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeLike.Services.Structures
{
    public interface IStatisticService
    {
        Result Create(Statistic photo);
        ICollection<Statistic> List();
    }
}