using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    
    public  class PhotoRepository : IPhotoRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public PhotoRepository(PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            _context = context;
        }

        public static string PhotoPath =  "/photos/";


        public async Task<Result> Create(Photo model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
              await _logger.AddExceptionLog(e);
                return   Result.Failed;
            }    
        }

        public async Task<IEnumerable<Photo>> List()
        {
            return _context.Photos.ToList();
        }

        public async Task<Photo> Get(long id)
        {
            return _context.Photos.FirstOrDefault(p => p.Id == id);
        }
  
        public async Task<Result> Update(Photo model)
        {
            try
            {
                _context.Update(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddExceptionLog(e);

                return   Result.Failed;
            }        
        }

        public async Task<Result> Delete(Photo model)
        {
            try
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
               await _logger.AddExceptionLog(e);

                return   Result.Failed;
            }
        }

        public async Task<Result> Create(Photo photo, long modelGalleryId)
        {
            try
            {
                var gallery = _context.Galleries
                    .Where(p => p.Id == modelGalleryId)
                    .Include(p=>p.Photos)
                    .SingleOrDefault();
                if (gallery == null) return Result.Failed;
                gallery.Photos.Add(photo);

                _context.SaveChanges();
                return  Result.Success;
            }
            catch (Exception e)
            {
               await _logger.AddExceptionLog(e);

                return   Result.Failed;
            }           
        }
    }
    
    public interface IPhotoRepository : IRepository<Photo>
    {
        Task<Result> Create(Photo photo, long modelGalleryId);
    }
}