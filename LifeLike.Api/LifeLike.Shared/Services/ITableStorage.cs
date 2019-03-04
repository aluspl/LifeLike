using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LifeLike.Shared.Services
{
    public interface ITableStorage
    {
        bool IsWorking { get;  }

        Task<IEnumerable<Statistic>> StatisticList();
        Task<IEnumerable<Log>> LogList();
        Task<IEnumerable<Log>> LogList(EventLogType type);
        Task<Result> Create(Statistic item);
        Task<Result> Delete(Statistic item);
        Task<Result> Create(Log item);
        Task<Result> Delete(Log item);
        Task<Result> DeleteAll(string v);
    }
}
