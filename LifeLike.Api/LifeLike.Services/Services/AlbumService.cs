﻿using System;
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

        public Album Get(string shortTitle)
        {            
                var gallery = _repo
                .GetOverviewQuery(p => p.ShortTitle == shortTitle)
                    .Include(p => p.Photos)
                    .SingleOrDefault();
                return _mapper.Map<Album>(gallery);          
        }
        public Album Get(long id)
        {
            var gallery = _repo
            .GetOverviewQuery(pp => pp.Id == id)
            .Include(p => p.Photos)
            .SingleOrDefault();

            return _mapper.Map<Album>(gallery);
        }

    }

    public interface IAlbumService
    {
        Result Create(Album model);
        Result Delete(long id);
        Album Get(string id);
        Album Get(long id);

        IEnumerable<Album> List();
        Result Update(Album model);
    }
}