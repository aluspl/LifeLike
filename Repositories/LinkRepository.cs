using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Models;
using LifeLike.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    
    public  class LinkRepository : ILinkRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;
        public LinkRepository(PortalContext context, IEventLogRepository logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Create(Link model)
        {
            try
            {
               await _context.AddAsync(model);
               await _context.SaveChangesAsync();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                     await _logger.AddException(e);

                return   Result.Failed;
            }    
        }

        public async Task<IEnumerable<Link>> List()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Link> Get(long id)
        {
            return await _context.Links.FindAsync(id);
        }
        public async Task<Link> Get(string id)
        {
            return await _context.Links.FirstOrDefaultAsync(p => p.Action == id);
        }
        public async Task<Result> Update(Link model)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return   Result.Failed;
            }        
        }

        public async Task<Result> Delete(Link model)
        {
            try
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                             await _logger.AddException(e);

                return   Result.Failed;
            }
        }

        public async Task<IEnumerable<Link>> List(LinkCategory category)
        {
            try
            {
                            return _context.Links.Where(p=>p.Category==category);

            }
            catch (System.Exception e)
            {
                await _logger.AddException(e);
                throw;
            }
        }
    }
    
    public interface ILinkRepository : IRepository<Link>
    {
        Task<IEnumerable<Link>> List(LinkCategory category);
        Task<Link> Get(string id);
    }
}