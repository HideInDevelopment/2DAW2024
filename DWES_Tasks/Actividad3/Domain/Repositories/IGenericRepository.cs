namespace Actividad3.Domain.Repositories;

public interface IGenericRepository<TKey, TEntity> where TEntity : class
{
    // CRUD Operations
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task AddAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task<TEntity?> DeleteAsync(TKey key);
}