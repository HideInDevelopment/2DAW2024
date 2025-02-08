using Actvidad3.Common.Storage.Repositories;
using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;

namespace Actvidad3.Common.Storage.Factories;

public class StorageRepositoryFactory : IStorageRepositoryFactory
{
    public StorageCatRepository CreateCatRepository(string filePath, IReadOnlyList<Cat> storedItems, EntityServiceManager<Guid, Cat> entityManager)
    {
        return new StorageCatRepository(filePath, storedItems, entityManager);
    }

    public StorageColonyRepository CreateColonyRepository(string filePath, IReadOnlyList<Colony> storedItems, EntityServiceManager<Guid, Colony> entityManager)
    {
        return new StorageColonyRepository(filePath, storedItems, entityManager);
    }

    public StoragePartnerRepository CreatePartnerRepository(string filePath, IReadOnlyList<Partner> storedItems, EntityServiceManager<Guid, Partner> entityManager)
    {
        return new StoragePartnerRepository(filePath, storedItems, entityManager);
    }

    public StorageColonyPartnerRepository CreateColonyPartnerRepository(string filePath, IReadOnlyList<ColonyPartner> storedItems, EntityServiceManager<Guid, ColonyPartner> entityManager)
    {
        return new StorageColonyPartnerRepository(filePath, storedItems, entityManager);
    }
}