using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly PortalContext _context;
        private readonly IEventLogRepository _logger;

        public PageRepository(PortalContext context, IEventLogRepository logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Create(Page model)
        {
            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> Create(Page model, Link link)
        {
            try
            {
                await _context.AddAsync(link);
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return Result.Failed;
            }
        }

        public async Task<IEnumerable<Page>> List()
        {
            try
            {
                return await _context.Pages.ToListAsync();
            }
            catch (System.Exception e)
            {
                await _logger.AddException(e);
                throw;
            }
        }

        public async Task<Page> Get(long id)
        {
            return await _context.Pages.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Page> Get(string id)
        {
            return await _context.Pages.FirstOrDefaultAsync(p => p.ShortName.Equals(id));
        }

        public async Task<Result> Update(Page model)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> Delete(Page model)
        {
            try
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return Result.Failed;
            }
        }

        public async Task<Result> Delete(Page model, Link link)
        {
            try
            {
                if (link != null)
                    _context.Remove(link);
                await Delete(model);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return Result.Failed;
            }
        }

        public async Task<IEnumerable<Page>> List(PageCategory category)
        {
            try
            {
                return await _context.Pages.Where(p => p.Category == category).ToListAsync();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return new List<Page>();
            }
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