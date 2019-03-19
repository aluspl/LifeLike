using LifeLike.Data.Models;
using LifeLike.Services.Structures;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using LifeLike.Shared.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using EventLogType = LifeLike.Shared.Enums.EventLogType;

namespace LifeLike.Services
{
    public class LogService : ILogService
    {
        private readonly ITableStorage _storage;

        public LogService(ITableStorage storage)
        {
            _storage = storage;
        }

        public Result AddException(Exception e)
        {
            try
            {
                if (!_storage.IsWorking) return Result.Success;
                var item = Log.Generate(e);
                return _storage.Create(item).Result;
            }
            catch (Exception)
            {
                Debug.WriteLine(e);
                return Result.Failed;
            }
        }
        public Result Create(Log model)
        {
            try
            {
                if (!_storage.IsWorking) return Result.Success;            
                return _storage.Create(model).Result;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Success;
            }
        }

        public IEnumerable<Log> List()
        {
            if (!_storage.IsWorking) return new List<Log>();

            return _storage.List().Result;
        }

        public IEnumerable<Log> List(EventLogType type)
        {
            if (!_storage.IsWorking) return new List<Log>();
            return _storage.List(type.ToString()).Result;
        }

        public Result LogInformation(EventLogType result, string information)
        {
            try
            {
                if (!_storage.IsWorking) return Result.Success;

                Create(Log.Generate(result, information));
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Failed;
            }
        }

        public Result DeleteAll()
        {
            try
            {
                if (!_storage.IsWorking) return Result.Success;

                _storage.DeleteAll("Logs");
                return Result.Success;
            }
            catch (Exception e)
            {
                AddException(e);
                return Result.Failed;
            }
        }

    }
}