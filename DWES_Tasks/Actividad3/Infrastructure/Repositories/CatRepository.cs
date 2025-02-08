using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories.Contracts;
using Actvidad3.Infrastructure.Persistence;

namespace Actvidad3.Domain.Repositories;

public class CatRepository(DatabaseContext context) : GenericRepository<Guid, Cat>(context), ICatRepository;