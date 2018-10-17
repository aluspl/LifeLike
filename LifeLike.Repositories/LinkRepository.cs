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
    
    public  class LinkRepository : ILinkRepository
    {
        private readonly IMapper _mapper;
        private readonly PortalContext _context;
        private readonly ILogService _logger;
        public LinkRepository(PortalContext context, ILogService logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Create(Link model)
        {
            try
            {
               await _context.AddAsync(_mapper.Map<LinkEntity>(model));
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
            var items =  await _context.Links.ToListAsync();
            return _mapper.Map<IEnumerable<Link>>(items);

        }

        public async Task<Link> Get(long id)
        {
            return await _context.Links.Where(p=>p.Id==id).ProjectTo<Link>().FirstOrDefaultAsync();
        }
        public async Task<Link> Get(string id)
        {
            return  await _context.Links.Where(p => p.Action == id).ProjectTo<Link>().FirstOrDefaultAsync();
        }
        public async Task<Result> Update(Link model)
        {
            try
            {
                var item = await _context.Links.FindAsync(model.Id);
                _mapper.Map(model,item);
                _context.Update(item);
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
                _context.Remove(_mapper.Map<LinkEntity>(model));
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
               return  await _context.Links.Where(p=>p.Category==category).ProjectTo<Link>().ToListAsync();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                throw;
            }
        }

        public async Task DeleteAsync(string shortName)
        {
            try{    
                var item = await _context.Links.Where(p => p.Action == shortName).FirstOrDefaultAsync();
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
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
        Task DeleteAsync(string shortName);
    }
}