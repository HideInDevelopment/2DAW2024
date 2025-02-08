using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;
  
public class StorageColonyRepository : StorageRepository<Guid, Colony>, IColonyRepository
{
    public StorageColonyRepository(string filePath, IReadOnlyList<Colony> storedItems, EntityServiceManager<Guid, Colony> entityManager)
        : base(filePath, storedItems, entityManager) { }
}