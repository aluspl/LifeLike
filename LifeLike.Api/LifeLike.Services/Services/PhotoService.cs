using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services.Structures;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LifeLike.Services
{
    public class PhotoService : BaseService<PhotoEntity>, IPhotoService
    {
        private readonly ILogService _logger;
        private readonly IBlobStorage _storage;
        private readonly IQueueService _queue;

        public PhotoService(IUnitOfWork uow, ILogService logger, IMapper mapper, IBlobStorage storage, IQueueService queue) : base(uow, mapper)
        {
            _logger = logger;
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
            try
            {
                var items = GetEntity(p => p.Id == id);
                return _mapper.Map<Photo>(items);
            }
            catch (Exception e)
            {
                _logger.AddException(e);

                return null;
            }
        }


        public Result Update(Photo model)
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

        public async Task<Result> Create(Photo model)
        {
            try
            {
                var photo = _mapper.Map<PhotoEntity>(model);
                string name = model.Stream?.FileName;
                using (var stream = model.Stream.OpenReadStream())
                {
                    photo.Url = await _storage.Create(stream, name, "photos");
                    photo.ThumbUrl = await _storage.CreateThumb(name, "thumbs");
                }
                using (var stream = model.Stream.OpenReadStream())
                {
                    //using (var thumb = Image.Load(stream))
                    //using (var thumbStream = new MemoryStream())
                    //{
                    //    thumb.Mutate(ctx => ctx.Resize(thumb.Width / 10, thumb.Height / 10));
                    //    thumb.Save(thumbStream, new JpegEncoder());
                    //}
                }
                CreateEntity(photo);
                _queue.SendNotification($"Photo: {photo.Id}");
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
                var entity = GetEntity(p => p.Id == id);
                _storage.Remove(entity.FileName, "photos");
                DeleteEntity(p => p.Id == id);
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