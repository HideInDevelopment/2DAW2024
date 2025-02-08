using Actvidad3.Common.Storage.Repositories;
using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;

namespace Actvidad3.Common.Storage.Factories;

public interface IStorageRepositoryFactory
{
    StorageCatRepository CreateCatRepository(string filePath, IReadOnlyList<Cat> storedItems, EntityServiceManager<Guid, Cat> entityManager);
    StorageColonyRepository CreateColonyRepository(string filePath, IReadOnlyList<Colony> storedItems, EntityServiceManager<Guid, Colony> entityManager);
    StoragePartnerRepository CreatePartnerRepository(string filePath, IReadOnlyList<Partner> storedItems, EntityServiceManager<Guid, Partner> entityManager);
    StorageColonyPartnerRepository CreateColonyPartnerRepository(string filePath, IReadOnlyList<ColonyPartner> storedItems, EntityServiceManager<Guid, ColonyPartner> entityManager);
}