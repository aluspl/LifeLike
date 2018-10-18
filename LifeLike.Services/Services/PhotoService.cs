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
    public  class PhotoService : BaseService<PhotoEntity>, IPhotoService
    {
        //TODO USE any blob storage api 
        private readonly ILogService _logger;

        public PhotoService(IUnitOfWork uow, ILogService logger, IMapper mapper) : base(uow, mapper)
        {
            _logger = logger;
        }

        public static readonly string PhotoPath =  "/photos/";


        public Result Create(Photo model)
        {
            try
            {
                var item = _mapper.Map<PhotoEntity>(model);
                _repo.Add(item);
                return Result.Success;

            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }

        public IEnumerable<Photo> List()
        {
            var items = _repo.GetOverview().AsEnumerable();
            return _mapper.Map<IEnumerable<Photo>>(items);

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

        public Result Delete(Photo model)
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

        public Result Create(Photo model, long modelGalleryId)
        {
            try
            {
                var photo = _mapper.Map<PhotoEntity>(model);
                // if (gallery == null) return Result.Failed;
                // gallery.Photos.Add();
                photo.Gallery = _unitOfWork.Get<GalleryEntity>().GetDetail(p=>p.Id==modelGalleryId);
                CreateEntity(photo);
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
        Result Create(Photo photo, long modelGalleryId);
    }
}