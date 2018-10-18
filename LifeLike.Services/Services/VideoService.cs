using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Data;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Services
{
    public class VideoService : BaseService<VideoEntity>, IVideoService
    {
        private readonly ILogService _logger;

        public VideoService(IUnitOfWork uow, ILogService logger, IMapper mapper ) : base(uow, mapper)
        {
            _logger = logger;
        }

        public Result Create(Video model)
        {
            try
            {
                var item = _mapper.Map<VideoEntity>(model);
                CreateEntity(item);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);

                return Result.Failed;
            }
        }

        public IEnumerable<Video> List()
        {
            var items = GetAllEntities();
            return _mapper.Map<IEnumerable<Video>>(items);

        }

        public Video Get(long id)
        {
            var item = GetEntity(o => o.Id == id);
            return _mapper.Map<Video>(item);
        }

        public Result Update(Video model)
        {
            try
            {
                var item = GetEntity(o => o.Id == model.Id);
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

        public Result Delete(Video model)
        {
            try
            {
                DeleteEntity(o => o.Id == model.Id);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);

                return Result.Failed;
            }
        }



        public IEnumerable<Video> List(VideoCategory category)
        {
            try
            {
                var items = _repo.GetOverviewQuery(p => p.Category == category).AsEnumerable();
                return _mapper.Map<IEnumerable<Video>>(items);
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return null;
            }
        }
    }

    public interface IVideoService
    {
        IEnumerable<Video> List(VideoCategory category);
    }
}