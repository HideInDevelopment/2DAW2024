using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Infrastructure.Persistence;

namespace Actividad3.Domain.Repositories;

public class PartnerRepository(DatabaseContext context) : GenericRepository<Guid, Partner>(context), IPartnerRepository;