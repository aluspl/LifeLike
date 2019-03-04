using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services.Structures;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using LifeLike.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeLike.Services.Cloud
{
    public class StatisticCloudService : IStatisticService
    {
        private readonly ILogService _logger;
        private readonly IMapper _mapper;
        private readonly ITableStorage _repo;

        public StatisticCloudService(ILogService logger, IMapper mapper, ITableStorage table)
        {
            _logger = logger;
            _mapper = mapper;
            _repo = table;
        }
        public ICollection<Statistic> List()
        {
            var items = _repo.StatisticList().Result.ToList();
            return items;
        }
         
        public Result Create(Statistic model)
        {
            try
            {              
                return  _repo.Create(model).Result;       
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }       
    }    
}