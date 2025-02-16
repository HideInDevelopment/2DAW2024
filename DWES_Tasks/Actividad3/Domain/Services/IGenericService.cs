namespace Actividad3.Domain.Services;

public interface IGenericService<in TKey, TDto>
{
    // CRUD Operations
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(TKey id);
    Task AddAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task DeleteAsync(TKey id);
}