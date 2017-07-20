using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;
using LifeLIke.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    
    public  class GalleryRepository : IGalleryRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public GalleryRepository(PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            _context = context;
        }

        public Result Create(Gallery model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);
                return   Result.Failed;
            }    
        }

        public IEnumerable<Gallery> List()
        {
            return _context.Galleries
                .Include(p=>p.Photos)
                .ToList();
        }

        public Gallery Get(long id)
        {
            var gallery = _context.Galleries
                .Where(p => p.Id == id)
                .Include(p=>p.Photos)
                .SingleOrDefault();
            return gallery;
        }

        public Result Update(Gallery model)
        {
            try
            {
                _context.Update(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);

                return   Result.Failed;
            }        
        }

        public Result Delete(Gallery model)
        {
            try
            {
                model = Get(model.Id);
                if (model==null) return Result.Failed;
                
                foreach (var photo in model.Photos)
                {
                    _context.Remove(photo);
                }
                _context.Remove(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);

                return  Result.Failed;
            }
        }

        public Gallery Get(string shortTitle)
        {
            try
            {
                var gallery = _context.Galleries
                    .Where(p => p.ShortTitle == shortTitle)
                    .Include(p=>p.Photos)
                    .SingleOrDefault();
                return gallery;
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);
                return null;
            }
        }
    }

    public interface IGalleryRepository: IRepository<Gallery>
    {
        Gallery Get(string id);
    }
}