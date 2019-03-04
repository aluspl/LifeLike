using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using System;
using System.Collections.Generic;

namespace LifeLike.Services.Structures
{
    public interface ILogService
    {
        Result AddException(Exception e);
        IEnumerable<Log> List(EventLogType type);
        Result LogInformation(EventLogType result, string message);
        IEnumerable<Log> List();
        Result DeleteAll();
    }
}
