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

    public Task<ColonyPartner?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public Task AddAsync(ColonyPartner entity) => _repository.AddAsync(entity);

    public Task UpdateAsync(ColonyPartner entity) => _repository.UpdateAsync(entity);

    public Task DeleteAsync(Guid key) => _repository.DeleteAsync(key);
}