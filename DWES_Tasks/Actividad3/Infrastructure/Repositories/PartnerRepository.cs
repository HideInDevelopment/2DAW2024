using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;
using Actvidad3.Infrastructure.Persistence;

namespace Actvidad3.Domain.Repositories;

public class PartnerRepository(DatabaseContext context) : GenericRepository<Guid, Partner>(context), IPartnerRepository;