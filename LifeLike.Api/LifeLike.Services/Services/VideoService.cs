using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.Extensions;
using LifeLike.Services.Structures;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LifeLike.Services
{
    public class VideoService : BaseService<VideoEntity>, IVideoService
    {
        private readonly ILogService _logger;

        public VideoService(IUnitOfWork uow, ILogService logger, IMapper mapper) : base(uow, mapper)
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
            Debug.WriteLine(items.ToJSON());
            return _mapper.Map<IEnumerable<Video>>(items);
        }

        public IEnumerable<Video> List(VideoCategory category)
        {
            var items = _repo.GetOverviewQuery(p => p.Category == category).AsEnumerable();
            Debug.WriteLine(items.ToJSON());
            return _mapper.Map<IEnumerable<Video>>(items);
        }
        public Video Get(string id)
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

        public Result Delete(string id)
        {
            try
            {
                DeleteEntity(o => o.Id == id);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }
    }

    public interface IVideoService
    {
        Result Create(Video model);
        Result Delete(string id);
        IEnumerable<Video> List(VideoCategory category);
        IEnumerable<Video> List();
    }
}