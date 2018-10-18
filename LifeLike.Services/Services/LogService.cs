using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeLike.Data;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services
{
    public class LogService : BaseService<EventLogEntity>, ILogService
    {
        private readonly IRepository<EventLogEntity> _context;

        public LogService(IUnitOfWork work, IMapper mapper) : base(work,mapper)
        {
            _context = _unitOfWork.Get<EventLogEntity>();
        }

        public Result AddException(Exception e)
        {
            try
            {
                Debug.WriteLine(e);

                return Create(Log.Generate(e));
            }
            catch (Exception)
            {
                Debug.WriteLine(e);
                return Result.Failed;
            }
        }

        public Result AddStat(string action, string controller)
        {
            try
            {
                return AddStat(string.Empty, action, controller);
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }

        public Result AddStat(string id, string action, string controller)
        {
            try
            {
                var model = new StatisticEntity
                {
                    Action = action,
                    Controller = controller,
                    Type = StatisticType.Method
                };

                return Result.Success;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }

        public Result Add(Log model)
        {
            try
            {
                return Create(model);
            }
            catch (Exception)
            {
                return Result.Success;
            }
        }

        public Result Create(Log model)
        {
            try
            {
                _context.Add(_mapper.Map<EventLogEntity>(model));
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Success;
            }
        }

        public IEnumerable<Log> List()
        {
            return _context.GetOverviewQuery(null).ProjectTo<Log>().AsEnumerable();
        }

        public IEnumerable<Log> List(EventLogType type)
        {
            return _context.GetOverviewQuery(p => p.Type == type).ProjectTo<Log>().AsEnumerable();
        }

        public Result LogInformation(int i, string information)
        {
            try
            {
                return Create(Log.Generate(i, information));
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Failed;
            }
        }

        public Result LogInformation(EventLogType result, string message)
        {
            try
            {
                Create(Log.Generate(result, message));
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Failed;
            }
        }

        public Result ClearLogs()
        {
            try
            {
                DeleteAll();
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                throw;
            }
        }

        public Log Get(long id)
        {
            var item = _context.GetDetail(p => p.Id == id);
            return _mapper.Map<Log>(item);
        }

        public Result Update(Log model)
        {
            try
            {
                EventLogEntity item = GetEntity(model.Id);
                _mapper.Map(model, item);
                _context.Update(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Failed;
            }
        }

        public Result Delete(long id)
        {
            try
            {
                EventLogEntity item = GetEntity(id);
                _context.Delete(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Failed;
            }
        }

        private EventLogEntity GetEntity(long id)
        {
            return _context.GetDetail(p => p.Id == id);
        }

        public Result DeleteAll()
        {
            try
            {
                _context.DeleteAll();
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Failed;
            }
        }

    }

    public interface ILogService 
    {
        Result AddException(Exception e);
        Result AddStat(string id, string action, string controller);
        Result AddStat(string action, string controller);

        IEnumerable<Log> List(EventLogType type);
        Result LogInformation(EventLogType result, string message);
        Result ClearLogs();
        Result Add(Log eventLog);
    }
}