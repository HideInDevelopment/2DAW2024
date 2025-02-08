using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;

public class ColonyRepository : IColonyRepository
{
    
    private IEnumerable<Colony> _storedColonyItems;
    private ManageEntityService<Colony> _entityManager;

    public ColonyRepository(IEnumerable<Colony> storedColonyItems, ManageEntityService<Colony> entityManager)
    {
        _storedColonyItems = storedColonyItems;
        _entityManager = entityManager;
    }
    public Task<IEnumerable<Colony>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Colony> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Colony entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Colony entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Colony entity)
    {
        throw new NotImplementedException();
    }
}