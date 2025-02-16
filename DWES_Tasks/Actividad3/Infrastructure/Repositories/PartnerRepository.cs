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
    
    public Task<IQueryable<Partner>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Partner?> GetByIdAsync(Guid id)
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

    public Task DeleteAsync(Guid key)
    {
        throw new NotImplementedException();
    }
}