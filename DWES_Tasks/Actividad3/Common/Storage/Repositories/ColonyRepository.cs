using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;

public class ColonyRepository(
    string filePath,
    IReadOnlyList<Colony> storedItems,
    ManageEntityService<Guid, Colony> entityManager)
    : GenericRepository<Guid, Colony>(filePath, storedItems, entityManager);