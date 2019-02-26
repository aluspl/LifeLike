using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Services.ViewModel;
using LifeLike.Shared;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeLike.Services
{
    public class PhotoService : BaseService<PhotoEntity>, IPhotoService
    {
        //TODO USE any blob storage api 
        private readonly ILogService _logger;
        private readonly IBlobStorage _storage;

        public PhotoService(IUnitOfWork uow, ILogService logger, IMapper mapper, IBlobStorage storage) : base(uow, mapper)
        {
            _logger = logger;
            _storage = storage;
        }
        public ICollection<Photo> List()
        {
            var items = _repo.GetOverview().ToList();
            return _mapper.Map<ICollection<Photo>>(items);
        }
        public Photo Get(long id)
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
                    photo.Url = await _storage.Create(stream, name);
                }
                CreateEntity(photo);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }
        public Result Delete(long id)
        {
            try
            {
                var entity = GetEntity(p => p.Id == id);
                _storage.Remove(entity.FileName);
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

    public interface IPhotoService
    {
        Task<Result> Create(Photo photo);
        Photo Get(long id);
        ICollection<Photo> List();
        Result Update(Photo photo);
        Result Delete(long id);

    }
}