using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;

namespace Actvidad3.Common.Storage.Repositories;

public class ColonyPartnerRepository(
    string filePath,
    IReadOnlyList<ColonyPartner> storedItems,
    ManageEntityService<Guid, ColonyPartner> entityManager)
    : GenericRepository<Guid, ColonyPartner>(filePath, storedItems, entityManager);