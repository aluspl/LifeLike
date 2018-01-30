using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LifeLike.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    
    public  class ConfigRepository : IConfigRepository
    {
        private readonly IEventLogRepository _logger;
        private readonly PortalContext _context;

        public ConfigRepository( PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            _context = context;
        }

        
        public async Task<Result> Create(Config model)
        {
            try
            {
                await  _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
              await _logger.AddException(e);
                return   Result.Failed;
            }    
        }

        public  async Task<IEnumerable<Config>> List()
        {
            try
            {
                return await _context.Configs.ToListAsync();

            }
            catch (System.Exception e)
            {
                await _logger.AddException(e);
                return new List<Config>();
            }
        }

        public async Task<Config> Get(long id)
        {
            return await _context.Configs.FirstOrDefaultAsync(p=>p.Name==id.ToString());
        }

        public async Task<Result> Update(Config model)
        {
            try
            {
                _context.Update(model);
                 _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return   Result.Failed;
            }        
        }

        public async Task<Result> Delete(Config model)
        {
            try
            {
                _context.Remove(model);
                 _context.SaveChanges();
                return  Result.Success;
                
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Config> Get(string id)
        {
            try
            {
                return await _context.Configs.FirstOrDefaultAsync(config => config.Name == id);
            }
            catch (Exception e)
            {
               await _logger.AddException(e);
               return null;
            };
        }

    }

    public interface IConfigRepository: IRepository<Config>
    {
        Task<Config> Get(string id);
    }
}