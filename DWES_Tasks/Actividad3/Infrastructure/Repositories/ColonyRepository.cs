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
    public Task<IQueryable<Colony>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Colony?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Colony entity)
    {
        throw new NotImplementedException();
    }

    public Task<Colony?> UpdateAsync(Colony entity)
    {
        throw new NotImplementedException();
    }

    public Task<Colony?> DeleteAsync(Guid key)
    {
        throw new NotImplementedException();
    }
}