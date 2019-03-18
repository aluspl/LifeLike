using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services.Structures;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;
using LifeLike.Shared.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
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
                using (var stream = model.Stream.OpenReadStream())
                {
                    string name = model.Stream?.FileName;
                    photo.FileName = name;
                    await ImageSetup(photo, stream);
                }
                CreateEntity(photo);
                //_queue.SendNotification($"Photo: {photo.Id}");
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }

        private async Task ImageSetup(PhotoEntity photo, Stream stream)
        {
            try
            {
                using (var image = Image.Load(stream))
                {
                    var metadata = image.MetaData;
                    await CreateThumb(photo, image);
                    await CreateImage(photo, image);
                };

            }
            catch (Exception e)
            {
                _logger.AddException(e);
            }


        }

        private async Task CreateImage(PhotoEntity photo,Image<SixLabors.ImageSharp.PixelFormats.Rgba32> image)
        {
            using (var outputStream = new MemoryStream())
            {
                image.Mutate(p => p.Resize(image.Width / 4, image.Height / 4));
                image.Save(outputStream, PngFormat.Instance);
                outputStream.Seek(0, SeekOrigin.Begin);

                photo.Url = await _storage.Create(new BlobItem
                {
                    Container = "photos",
                    Stream = outputStream,
                    Name = photo.FileName
                });
            }          
        }

        private async Task CreateThumb(PhotoEntity photo, Image<SixLabors.ImageSharp.PixelFormats.Rgba32> image)
        {
            using (var thumb = image.Clone())
            using (var outputStream = new MemoryStream())
            {
                thumb.Mutate(p => p.Resize(image.Width / 10, image.Height / 10));
                thumb.Save(outputStream, PngFormat.Instance);
                outputStream.Seek(0, SeekOrigin.Begin);
                photo.ThumbUrl = await _storage.Create(
                    new BlobItem
                    {
                        Container = "thumbs",
                        Stream = outputStream,
                        Name = photo.FileName
                    });
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