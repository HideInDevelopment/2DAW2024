using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;

public class CatRepository : ICatRepository
{
    private IEnumerable<Cat> _storedCatItems;
    private ManageEntityService<Cat> _entityManager;

    public CatRepository(IEnumerable<Cat> storedCatItems, ManageEntityService<Cat> entityManager)
    {
        _storedCatItems = storedCatItems;
        _entityManager = entityManager;
    }
    public Task<IEnumerable<Cat>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Cat> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Cat entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Cat entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Cat entity)
    {
        throw new NotImplementedException();
    }
}