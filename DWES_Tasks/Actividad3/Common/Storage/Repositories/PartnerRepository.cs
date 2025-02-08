using Actvidad3.Common.Storage.Services;
using Actvidad3.Common.Validators;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;

namespace Actvidad3.Common.Storage.Repositories;

public class PartnerRepository(
    string filePath,
    IReadOnlyList<Partner> storedItems,
    ManageEntityService<Guid, Partner> entityManager)
    : GenericRepository<Guid, Partner>(filePath, storedItems, entityManager);