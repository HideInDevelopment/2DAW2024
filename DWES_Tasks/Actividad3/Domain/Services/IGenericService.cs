namespace Actividad3.Domain.Services;

public interface IGenericService<TKey, TEntity, TDto> where TEntity : class
{
    // CRUD Operations
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(TKey id);
    Task<TDto?> AddAsync(TDto dto);
    Task<TDto?> UpdateAsync(TDto dto);
    Task<TDto?> DeleteAsync(TKey id);
}