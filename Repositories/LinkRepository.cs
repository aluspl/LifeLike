using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;

namespace LifeLike.Repositories
{
    
    public  class LinkRepository : ILinkRepository
    {
        private readonly PortalContext _context;

        public LinkRepository(PortalContext context)
        {
            _context = context;
        }

        public Result Create(Link model)
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

        public IEnumerable<Link> List()
        {
            return _context.Links.ToList();
        }

        public Link Get(long id)
        {
            return _context.Links.Find(id);
        }

        public Result Update(Link model)
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

        public Result Delete(Link model)
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

        public IEnumerable<Link> List(LinkCategory category)
        {
            return _context.Links.Where(p=>p.Category==category);
        }
    }
    
    public interface ILinkRepository : IRepository<Link>
    {
        IEnumerable<Link> List(LinkCategory category);
    }
}