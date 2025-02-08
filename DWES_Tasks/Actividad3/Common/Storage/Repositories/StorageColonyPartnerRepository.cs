using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;

namespace Actvidad3.Common.Storage.Repositories;

public class StorageColonyPartnerRepository : StorageRepository<Guid, ColonyPartner>, IColonyPartnerRepository
{
    public StorageColonyPartnerRepository(string filePath, IReadOnlyList<ColonyPartner> storedItems, EntityServiceManager<Guid, ColonyPartner> entityManager)
        : base(filePath, storedItems, entityManager) { }
}