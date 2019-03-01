using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services.Structures;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using System;
using System.Collections.Generic;

namespace LifeLike.Services
{
    public class StatisticService : BaseService<StatisticEntity>, IStatisticService
    {
        private ILogService _logger;

        public StatisticService(IUnitOfWork work, ILogService logger, IMapper mapper) : base(work, mapper)
        {
            _logger = logger;
        }

        public Result Create(Statistic model)
        {
            try
            {
                var item = _mapper.Map<StatisticEntity>(model);
                CreateEntity(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }

        public ICollection<Statistic> List()
        {
            try
            {
                var items = GetAllEntities();
                return _mapper.Map<ICollection<Statistic>>(items);
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return new List<Statistic>();
            }
        }

        public Link Get(string id)
        {
            var item = GetEntity(p => p.Action == id);
            return _mapper.Map<Link>(item);
        }

        public Result Update(Statistic model)
        {
            try
            {
                var item = GetEntity(p => p.Id == model.Id);
                _mapper.Map(model, item);
                UpdateEntity(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }

        public Result Delete(Statistic model)
        {
            try
            {
                DeleteEntity(p => p.Id == model.Id);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }
        public Result Delete(string shortName)
        {
            try
            {
                DeleteEntity(p => p.Action == shortName);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }
    }
}