using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Model;
using LifeLike.Shared.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeLike.Services
{
    public class PhotoService : BaseService<PhotoEntity>, IPhotoService
    {
        private readonly IBlobStorage _storage;
        private readonly IQueueService _queue;

        public PhotoService(IRepository<PhotoEntity> repo, IMapper mapper, IBlobStorage storage, IQueueService queue) : base(repo, mapper)
        {
            _storage = storage;
            _queue = queue;
        }

        public ICollection<Photo> List()
        {
            var items = _repo.GetOverview().ToList();
            return _mapper.Map<ICollection<Photo>>(items);
        }

        public Photo Get(string id)
        {
            var items = GetEntity(p => p.Id == id);
            return _mapper.Map<Photo>(items);
        }


        public Result Update(Photo model)
        {
            var item = GetEntity(p => p.Id == model.Id);
            _mapper.Map(model, item);
            UpdateEntity(item);
            return Result.Success;
        }

        public async Task<Result> Create(Photo model)
        {
            var photo = _mapper.Map<PhotoEntity>(model);
            string name = model.Stream?.FileName;
            using (var stream = model.Stream.OpenReadStream())
            {
                photo.Url = await _storage.Create(stream, name, "photos");
                photo.ThumbUrl = await _storage.CreateThumb(name, "thumbs");
            }
            CreateEntity(photo);
            _queue.SendNotification($"Photo: {photo.Id}");
            return Result.Success;

        }

        public Result Delete(string id)
        {
            var entity = GetEntity(p => p.Id == id);
            _storage.Remove(entity.FileName, "photos");
            DeleteEntity(p => p.Id == id);
            return Result.Success;
        }
    }
}