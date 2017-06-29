using System;
using System.Collections.Generic;
using System.Linq;
using LifeLike.Models;
using LifeLike.Models.Enums;

namespace LifeLike.Repositories
{
    
    public  class PageRepository : IPageRepository
    {
        private readonly PortalContext _context;

        public PageRepository(PortalContext context)
        {
            _context = context;
        }

        public Result Create(Page model)
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
        public Result Create(Page model, Link link)
        {
            try
            {
                _context.Add(model);
                _context.Add(link);
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
        public IEnumerable<Page> List()
        {
            return _context.Pages.ToList();
        }

        public Page Get(long id)
        {
            return _context.Pages.Find(id);
        }
        public Page Get(string id)
        {
            return _context.Pages.FirstOrDefault(p=>p.ShortName.Equals(id));
        }

        public Result Update(Page model)
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

        public Result Delete(Page model)
        {
            try
            {
                var link = _context.Links.FirstOrDefault(p => p.Id == model.LinkId);
                if (link!=null) _context.Remove(link);
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

        public IEnumerable<Page> List(PageCategory category)
        {
            return _context.Pages.Where(p=>p.Category==category);
        }
    }
    
    public interface IPageRepository : IRepository<Page>
    {
        IEnumerable<Page> List(PageCategory category);
        Page Get(string id);
        Result Create(Page model, Link link);
    }
}