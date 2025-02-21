using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Infrastructure.Persistence;

namespace Actividad3.Domain.Repositories;

public class ColonyRepository: IColonyRepository
{
    
    private readonly IGenericRepository<Guid, Colony> _repository;

    public ColonyRepository(IGenericRepository<Guid, Colony> repository)
    {
        _repository = repository;
    }
    public Task<IQueryable<Colony>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Colony?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public Task AddAsync(Colony entity) => _repository.AddAsync(entity);

    public Task UpdateAsync(Colony entity) => _repository.UpdateAsync(entity);

    public Task DeleteAsync(Guid key) => _repository.DeleteAsync(key);
}