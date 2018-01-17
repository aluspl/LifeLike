using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;

namespace LifeLike.Repositories
{
    
    public  class PageRepository : IPageRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public PageRepository(PortalContext context, IEventLogRepository logger)
        {
            _context = context;
            _logger= logger;
        }

        public async Task<Result> Create(Page model)
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
        public async Task<Result> Create(Page model, Link link)
        {
            try
            {
                _context.Add(link);               
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
        public async Task<IEnumerable<Page>> List()
        {
            return _context.Pages.ToList();
        }

        public async Task<Page> Get(long id)
        {
            return _context.Pages.Find(id);
        }
        public async Task<Page> Get(string id)
        {
            return _context.Pages.FirstOrDefault(p=>p.ShortName.Equals(id));
        }

        public async Task<Result> Update(Page model)
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

        public async Task<Result> Delete(Page model)
        {
            //Always True!! :D 
         return   Result.Success;
        }

        public async Task<Result> Delete(Page model, Link link)
        {
            try
            {
               if (link!=null) _context.Remove(link);
                _context.Remove(model);
                _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddExceptionLog(e);

                return   Result.Failed;
            }
        }

        public async Task<IEnumerable<Page>> List(PageCategory category)
        {
            return _context.Pages.Where(p=>p.Category==category);
        }
    }
    
    public interface IPageRepository : IRepository<Page>
    {
         Task<IEnumerable<Page>> List(PageCategory category);
         Task<Page> Get(string id);
         Task<Result> Create(Page model, Link link);
         Task<Result> Delete(Page model, Link link);

    }
}