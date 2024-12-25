using System.Text.Json;
using Actividad2.Domain.Entity;
using Actividad2.Domain.Generic.Interface;
using Actividad2.Functions;

namespace Actividad2.Domain.Repository;

public class CatRepository : IEntityRepository<Guid, Cat>
{
    private readonly string _catsPath = ExtensionFunctions.GetSpecificPath("Dynamic", "cats.json");
    private readonly IGenericRepository<Guid, Cat> _catRepository;
    private List<Cat> _cats;

    public CatRepository(IGenericRepository<Guid, Cat> catRepository)
    {
        _catRepository = catRepository;
        _cats = FillWithCats() ?? [];
    }
    
    // public IQueryable<Cat> Get() => repository.GetAll();
    //
    // public Cat? Get(Guid id) => repository.GetById(id);
    //
    // public Cat? Create(Cat entity) => repository.Add(entity);
    //
    // public Cat? Update(Cat entity) => repository.Update(entity);
    //
    // public Cat? Delete(Guid id) => repository.Delete(id);
    
    public IQueryable<Cat> Get() => 
        ExtensionFunctions.IsNullOrEmpty(_cats) ? new List<Cat>().AsQueryable() : _cats.AsQueryable();
    

    public Cat? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Cat? Create(Cat entity)
    {
        throw new NotImplementedException();
    }

    public Cat? Update(Cat entity)
    {
        throw new NotImplementedException();
    }

    public Cat? Delete(Guid id)
    {
        throw new NotImplementedException();
    }
    
    private List<Cat>? FillWithCats()
    {
        var jsonCats = File.ReadAllText(_catsPath);
        return JsonSerializer.Deserialize<List<Cat>>(jsonCats);
    }
}