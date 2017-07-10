using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLIke.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    
    public  class PhotoRepository : IPhotoRepository
    {
        private readonly PortalContext _context;
        private IEventLogRepository _logger;

        public PhotoRepository(PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            _context = context;
        }

        public Result Create(Photo model)
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

        public IEnumerable<Photo> List()
        {
            return _context.Photos.ToList();
        }

        public Photo Get(long id)
        {
            return _context.Photos.FirstOrDefault(p => p.Id == id);
        }
  
        public Result Update(Photo model)
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

        public Result Delete(Photo model)
        {
            try
            {
                _context.Remove(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);

                return   Result.Failed;
            }
        }

        public Result Create(Photo photo, long modelGalleryId)
        {
            try
            {
                var gallery = _context.Galleries
                    .Where(p => p.Id == modelGalleryId)
                    .Include(p=>p.Photos)
                    .SingleOrDefault();
                if (gallery == null) return Result.Failed;
                gallery.Photos.Add(photo);
//                _context.Add(photo);    
//                _context.Update(gallery);
                _context.SaveChanges();
                return  Result.Success;
            }
            catch (Exception e)
            {
                _logger.AddExceptionLog(e);

                return   Result.Failed;
            }           
        }
    }
    
    public interface IPhotoRepository : IRepository<Photo>
    {
        Result Create(Photo photo, long modelGalleryId);
    }
}