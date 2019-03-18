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
        Task<IEnumerable<Log>> List();
        Task<IEnumerable<Log>> List(string type);
        Task<Result> Update(string id, Log value);
        Task<Result> Create(Log item);
        Task<Result> Delete(Log item);
        Task<Result> DeleteAll(string v);
    }
}
