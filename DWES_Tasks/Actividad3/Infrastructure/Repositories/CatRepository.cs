using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories.Contracts;

namespace Actividad3.Domain.Repositories;

public class CatRepository : ICatRepository
{
    private readonly IGenericRepository<Guid, Cat> _repository;

    public CatRepository(IGenericRepository<Guid, Cat> repository)
    {
        _repository = repository;
    }

    public Task<IQueryable<Cat>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Cat?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public Task AddAsync(Cat entity) => _repository.AddAsync(entity);

    public Task<Cat?> UpdateAsync(Cat entity) => _repository.UpdateAsync(entity);

    public Task<Cat?> DeleteAsync(Guid key) => _repository.DeleteAsync(key);
}