using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services.Extensions;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LifeLike.Services
{
    public class VideoService : BaseService<VideoEntity>, IVideoService
    {

        public VideoService(IRepository<VideoEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Result Create(Video model)
        {
            var item = _mapper.Map<VideoEntity>(model);
            CreateEntity(item);
            return Result.Success;
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
            var item = GetEntity(o => o.Id == model.Id);
            _mapper.Map(model, item);
            UpdateEntity(item);
            return Result.Success;
        }

        public Result Delete(string id)
        {
            DeleteEntity(o => o.Id == id);
            return Result.Success;
        }
    }


}