using Actividad3.Domain.Entities;
using Actividad3.Infrastructure.Persistence;

namespace Actividad3.Domain.Repositories;

public class ColonyPartnerRepository(DatabaseContext context)
    : GenericRepository<Guid, ColonyPartner>(context), IColonyPartnerRepository;