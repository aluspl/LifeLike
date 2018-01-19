using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Result> Create(Link model)
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

        public async Task<IEnumerable<Link>> List()
        {
            return _context.Links.ToList();
        }

        public async Task<Link> Get(long id)
        {
            return await _context.Links.FindAsync(id);
        }
        public async Task<Link> Get(string id)
        {
            return _context.Links.FirstOrDefault(p => p.Action == id);
        }
        public async Task<Result> Update(Link model)
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

        public async Task<Result> Delete(Link model)
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

        public async Task<IEnumerable<Link>> List(LinkCategory category)
        {
            return _context.Links.Where(p=>p.Category==category);
        }
    }
    
    public interface ILinkRepository : IRepository<Link>
    {
        Task<IEnumerable<Link>> List(LinkCategory category);
        Task<Link> Get(string id);
    }
}