using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly ILinkRepository _link;
        private readonly PortalContext _context;
        private readonly IMapper _mapper;
        private readonly IEventLogRepository _logger;

        public PageRepository(PortalContext context, 
            IEventLogRepository logger,
            ILinkRepository link,
            IMapper mapper)
        {
            _link = link;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Create(Page model)
        {
            try
            {
                var item = await Get(model.ShortName);
                if (item != null)
                   model.ShortName=model.ShortName+1;
                await _context.AddAsync(_mapper.Map<Page>(model));
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
               
                await _link.Create(link);
                await Create(model); 
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return Result.Failed;
            }
        }

        public async Task<IEnumerable<PageEntity>> List()
        {
            try
            {
                return await _context.Pages.ToListAsync();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                throw;
            }
        }

        public async Task<Page> Get(long id)
        {
            return await _context.Pages.Where(predicate=>predicate.LinkId == id).ProjectTo<Page>().FirstOrDefaultAsync();
        }

        public async Task<Page> Get(string id)
        {
            if (id == null) return null;
            return await _context.Pages.Where(p => p.ShortName.Equals(id)).ProjectTo<Page>().FirstOrDefaultAsync();
        }
        public async Task<bool> Any(string id)
        {
            if (id == null) return false;
            return await _context.Pages.Where(p => p.ShortName.Equals(id)).AnyAsync();
        }
        public async Task<Result> Update(Page model)
        {
            try
            {
                PageEntity item = await GetItem(model);
                _mapper.Map(model, item);
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }

        private async Task<PageEntity> GetItem(Page model)
        {
            return await _context.Pages.Where(pr => pr.ShortName == model.ShortName).FirstOrDefaultAsync();
        }

        public async Task<Result> Delete(Page model)
        {
            try
            {
                await _link.DeleteAsync(model.ShortName);
                PageEntity item = await GetItem(model);

                _context.Remove(item);
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
                return await _context.Pages.Where(p => p.Category == category).ProjectTo<Page>().ToListAsync();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);

                return new List<Page>();
            }
        }

        async Task<IEnumerable<Page>> IRepository<Page>.List()
        {
            return await _context.Pages.ProjectTo<Page>().ToListAsync();
        }
    }

    public interface IPageRepository : IRepository<Page>
    {
        Task<IEnumerable<Page>> List(PageCategory category);
        Task<Page> Get(string id);
        Task<Result> Create(Page model, Link link);
    }
}