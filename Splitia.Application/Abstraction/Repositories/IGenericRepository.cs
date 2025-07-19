namespace Splitia.Application.Abstraction.Repositories;

public interface IGenericRepository<T> : IDisposable
{
    Task<T> InsertAsync(T entity);
    void Update(T entity);
    Task<T> SoftDelete(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> GetAll();
}