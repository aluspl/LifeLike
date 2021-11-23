using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Database.Data.Repository
{
    public class PageRepository : GenericRepository<PageEntity>, IPageRepository
    {
        public PageRepository(EFContext context)
        : base(context)
        {
        }

        public override async Task<PageEntity> Get(Expression<Func<PageEntity, bool>> predicate = null)
        {
            return await GetWithIncludes().FirstOrDefaultAsync(predicate);
        }

        public override async Task<IEnumerable<PageEntity>> GetAll()
        {
            return await GetWithIncludes().ToListAsync();
        }

        public override IQueryable<PageEntity> Find(Expression<Func<PageEntity, bool>> predicate)
        {
            return GetWithIncludes().Where(predicate);
        }

        public override IQueryable<PageEntity> FindSlim(Expression<Func<PageEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        private IQueryable<PageEntity> GetWithIncludes()
        {
            var baseQuery = (IQueryable<PageEntity>)Entities;

            return baseQuery
                .Include(p => p.Categories)
                .Include(p => p.Contents)
                .Include(p => p.Link)
                .Include(p => p.Image)
                .AsSplitQuery();
        }
    }
}
