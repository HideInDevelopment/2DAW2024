using Actividad2.Domain.Entity;
using Actividad2.Domain.Generic.Interface;

namespace Actividad2.Domain.Repository;

public class CatRepository(IGenericRepository<Guid, Cat> repository) : IEntityRepository<Guid, Cat>
{
    public IQueryable<Cat> Get() => repository.GetAll();

    public Cat? Get(Guid id) => repository.GetById(id);

    public Cat? Create(Cat entity) => repository.Add(entity);

    public Cat? Update(Cat entity) => repository.Update(entity);

    public Cat? Delete(Guid id) => repository.Delete(id);
}