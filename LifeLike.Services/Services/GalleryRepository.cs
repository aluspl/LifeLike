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
    public class AlbumService : BaseService<GalleryEntity>, IAlbumService
    {
        private readonly ILogService _logger;

        public AlbumService(UnitOfWork uow, ILogService logger, IMapper mapper) : base(unitOfWork: uow, mapper: mapper)
        {
            _logger = logger;
        }

        public Result Create(Album model)
        {
            try
            {
                var gallery = _mapper.Map<GalleryEntity>(model);
                CreateEntity(gallery);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return Result.Failed;
            }
        }

        public IEnumerable<Album> List()
        {
            var items = _repo
            .GetOverviewQuery()
            .Include(p => p.Photos)
            .AsEnumerable();

            return _mapper.Map<IEnumerable<Album>>(items);
        }

        public Album Get(long id)
        {
            var gallery = _repo
            .GetOverviewQuery(pp => pp.Id == id)
            .Include(p => p.Photos)
            .SingleOrDefault();

            return _mapper.Map<Album>(gallery);
        }

        public Result Update(Album model)
        {
            try
            {
                var item = GetEntity(pp => pp.Id == model.Id);

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

        public Result Delete(long id)
        {
            try
            {
                DeleteEntity(pp=>pp.Id==id);
                return Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddException(e);

                return Result.Failed;
            }
        }

        private GalleryEntity GetEntity(long id)
        {
            return  _repo.GetDetail(pp=>pp.Id==id);
        }

        public Album Get(string shortTitle)
        {
            try
            {
                var gallery = _repo.GetOverviewQuery(p => p.ShortTitle == shortTitle)
                    .Include(p => p.Photos)
                    .SingleOrDefault();
                return _mapper.Map<Album>(gallery);
            }
            catch (Exception e)
            {
                _logger.AddException(e);
                return null;
            }
        }
    }

    public interface IAlbumService
    {
        Album Get(string id);
    }
}