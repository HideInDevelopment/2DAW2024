using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;

public class PartnerRepository : IPartnerRepository
{
    private IEnumerable<Partner> _storedPartnerItems;
    private ManageEntityService<Partner> _entityManager;

    public PartnerRepository(IEnumerable<Partner> storedPartnerItems, ManageEntityService<Partner> entityManager)
    {
        _storedPartnerItems = storedPartnerItems;
        _entityManager = entityManager;
    }
    public Task<IEnumerable<Partner>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Partner> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Partner entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Partner entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Partner entity)
    {
        throw new NotImplementedException();
    }
}