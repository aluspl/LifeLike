using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;

namespace LifeLike.Repositories
{
    
    public  class PhotoRepository : IPhotoRepository
    {
        private readonly PortalContext _context;

        public PhotoRepository(PortalContext context)
        {
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
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
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
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
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
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
                return   Result.Failed;
            }
        }

     
    }
    
    public interface IPhotoRepository : IRepository<Photo>
    {
    }
}