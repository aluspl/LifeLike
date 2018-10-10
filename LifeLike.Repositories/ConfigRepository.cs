using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly IEventLogRepository _logger;
        private readonly PortalContext _context;

        public ConfigRepository(PortalContext context, IEventLogRepository logger)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<Result> Create(Config model)
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

        public async Task<IEnumerable<Config>> List()
        {
            try
            {
                return await _context.Configs.ProjectTo<Config>().ToListAsync();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return new List<Config>();
            }
        }

        public async Task<Config> Get(long id)
        {
            return await _context.Configs.Where(p => p.Id == id).ProjectTo<Config>().FirstOrDefaultAsync();
        }

        public async Task<Result> Update(Config model)
        {
            try
            {
                _context.Update(model);
                _context.SaveChanges();
                return Result.Success;
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return Result.Failed;
            }
        }

        public async Task<Result> Delete(Config model)
        {
            try
            {
                _context.Remove(model);
                _context.SaveChanges();
                return Result.Success;
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
                return await _context.Configs.Where(p => p.Name == id).ProjectTo<Config>().FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                await _logger.AddException(e);
                return null;
            }
        }
    }

    public interface IConfigRepository : IRepository<Config>
    {
        Task<Config> Get(string id);
    }
}