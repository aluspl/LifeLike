using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.ViewModel;

namespace LifeLike.Repositories
{
    
    public  class GalleryRepository : IGalleryRepository
    {
        private readonly PortalContext _context;

        public GalleryRepository(PortalContext context)
        {
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
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
                return   Result.Failed;
            }    
        }

        public IEnumerable<Gallery> List()
        {
            return _context.Galleries.ToList();
        }

        public Gallery Get(long id)
        {
            return _context.Galleries.Find(id);
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
                _context.EventLogs.Add(EventLog.Generate(e));
                _context.SaveChanges();
                return   Result.Failed;
            }        
        }

        public Result Delete(Gallery model)
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

        public Gallery Get(string shortTitle)
        {
            return _context.Galleries.FirstOrDefault(id=>id.ShortTitle==shortTitle);
        }
    }

    public interface IGalleryRepository: IRepository<Gallery>
    {
        Gallery Get(string id);
    }
}