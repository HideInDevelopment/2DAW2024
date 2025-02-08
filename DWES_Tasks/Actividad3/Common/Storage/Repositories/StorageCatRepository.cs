using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;

public class StorageCatRepository : StorageRepository<Guid, Cat>, ICatRepository
{
    public StorageCatRepository(string filePath, IReadOnlyList<Cat> storedItems, EntityServiceManager<Guid, Cat> entityManager)
        : base(filePath, storedItems, entityManager) { }
}