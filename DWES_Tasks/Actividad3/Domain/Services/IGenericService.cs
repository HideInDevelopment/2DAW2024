namespace Actvidad3.Domain.Services;

public interface IGenericService<TKey, TEntity, TDto> where TEntity : class
{
    // CRUD Operations
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(TKey id);
    Task AddAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task DeleteAsync(TKey id);
}