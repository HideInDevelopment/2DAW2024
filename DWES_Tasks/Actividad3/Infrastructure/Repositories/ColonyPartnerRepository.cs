using Actividad3.Domain.Entities;
using Actividad3.Infrastructure.Persistence;

namespace Actividad3.Domain.Repositories;

public class ColonyPartnerRepository : IColonyPartnerRepository
{
    private readonly IGenericRepository<Guid, ColonyPartner> _repository;

    public ColonyPartnerRepository(IGenericRepository<Guid, ColonyPartner> repository)
    {
        _repository = repository;
    }
    public Task<IQueryable<ColonyPartner>> GetAllAsync() => _repository.GetAllAsync();

    public Task<ColonyPartner?> GetByIdAsync(Guid id)
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

    public Task DeleteAsync(Guid key)
    {
        throw new NotImplementedException();
    }
}