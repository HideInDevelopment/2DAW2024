using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Infrastructure.Persistence;

namespace Actividad3.Domain.Repositories;

public class PartnerRepository: IPartnerRepository
{
    private readonly IGenericRepository<Guid, Partner> _repository;

    public PartnerRepository(IGenericRepository<Guid, Partner> repository)
    {
        _repository = repository;
    }
    
    public Task<IQueryable<Partner>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Partner?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public Task AddAsync(Partner entity) => _repository.AddAsync(entity);

    public Task UpdateAsync(Partner entity) => _repository.UpdateAsync(entity);

    public Task DeleteAsync(Guid key) => _repository.DeleteAsync(key);
}