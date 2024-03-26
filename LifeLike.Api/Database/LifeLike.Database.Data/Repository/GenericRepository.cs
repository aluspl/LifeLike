using System.Linq.Expressions;
using LifeLike.Common.Exceptions;
using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LifeLike.Database.Data.Repository;

public class GenericRepository<T> : IRepository<T>
    where T : BaseEntity
{
    public GenericRepository(EfContext context)
    {
        Context = context;
        Entities = Context.Set<T>();
    }

    protected EfContext Context { get; set; }

    protected DbSet<T> Entities { get; set; }

    public virtual Task<T> Get(Expression<Func<T, bool>> predicate = null)
    {
        return Entities.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await Entities.ToListAsync();
    }

    public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return Entities.Where(predicate);
    }

    public virtual IQueryable<T> FindSlim(Expression<Func<T, bool>> predicate)
    {
        return Entities.Where(predicate);
    }

    public virtual async Task<T> Add(T entity)
    {
        await Entities.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Delete(Expression<Func<T, bool>> predicate)
    {
        var entity = await Entities.FirstOrDefaultAsync(predicate) ?? throw new NotFoundException($"{typeof(T).Name}");
        DeleteAction(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> Update(T entity)
    {
        var item = await Entities.FindAsync(entity.Id) ?? throw new NotFoundException($"{typeof(T).Name} with {entity.Id}");

        Context.Attach(item).CurrentValues.SetValues(entity);
        Context.Entry(item).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return item;
    }

    public virtual async Task<T> Delete(Guid id)
    {
        var entity = await Entities.FindAsync(id);

        DeleteAction(entity);

        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<long> Count(Expression<Func<T, bool>> predicate)
    {
        return await Entities.CountAsync(predicate);
    }

    public virtual async Task<bool> Any(Expression<Func<T, bool>> predicate)
    {
        return await Entities.AnyAsync(predicate);
    }

    protected virtual void DeleteAction(T entity)
    {
        Entities.Remove(entity);
    }
}