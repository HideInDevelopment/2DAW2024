using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;

namespace Actvidad3.Common.Storage.Repositories;

public class ColonyPartnerRepository : IColonyPartnerRepository
{
    private IEnumerable<ColonyPartner> _storedColonyPartnerItems;
    private ManageEntityService<ColonyPartner> _entityManager;

    public ColonyPartnerRepository(IEnumerable<ColonyPartner> storedColonyPartnerItems, ManageEntityService<ColonyPartner> entityManager)
    {
        _storedColonyPartnerItems = storedColonyPartnerItems;
        _entityManager = entityManager;
    }

    public Task<IEnumerable<ColonyPartner>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ColonyPartner> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(ColonyPartner entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ColonyPartner entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(ColonyPartner entity)
    {
        throw new NotImplementedException();
    }
}