using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;
public class StoragePartnerRepository : StorageRepository<Guid, Partner>, IPartnerRepository
{
    public StoragePartnerRepository(string filePath, IReadOnlyList<Partner> storedItems, EntityServiceManager<Guid, Partner> entityManager)
        : base(filePath, storedItems, entityManager) { }
}