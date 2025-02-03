using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;
using Actvidad3.Infrastructure.Persistence;

namespace Actvidad3.Domain.Repositories;

public class ColonyRepository : GenericRepository<Guid, Colony>, IColonyRepository
{
    public ColonyRepository(DatabaseContext context) : base(context)
    {
    }
}