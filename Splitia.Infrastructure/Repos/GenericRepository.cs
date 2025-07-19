using Microsoft.EntityFrameworkCore;
using Splitia.Application.Abstraction.Repositories;
using Splitia.Domain;
using Splitia.Infrastructure.DbContext;

namespace Splitia.Infrastructure.Repos;

public class GenericRepository<T>(SplitiaContext context) : IGenericRepository<T>
    where T : AuditEntity
{
    protected DbSet<T> Entities => context.Set<T>();


    public async Task<T> InsertAsync(T entity)
    {
        var entry = await context.Set<T>().AddAsync(entity);
        return entry.Entity;
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Entities.FindAsync(id);
    }

    public async Task<T> SoftDelete(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        entity.SetAsDeleted();
        return entity;
    }

    public IQueryable<T> GetAll()
    {
        return Entities.AsQueryable();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}