using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;

namespace Actvidad3.Common.Storage.Repositories;

public class CatRepository(
    string filePath,
    IReadOnlyList<Cat> storedItems,
    ManageEntityService<Guid, Cat> entityManager)
    : GenericRepository<Guid, Cat>(filePath, storedItems, entityManager);