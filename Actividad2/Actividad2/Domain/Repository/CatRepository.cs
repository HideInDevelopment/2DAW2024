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
    
    public Cat? Get(Guid id) => _cats.FirstOrDefault(c => c.Id == id);
    
    public Cat? Create(Cat entity)
    {
        if (_cats.All(c => c.Id != entity.Id))
        {
            _cats.Add(entity);
            PersistInJsonFile();
            return entity;
        }
        else
            return null;
    }

    public Cat? Update(Cat entity)
    {
        if (_cats.Any(c => c.Id == entity.Id))
        {
            UpdateCat(entity);
            PersistInJsonFile();
            return entity;
        }
        else
            return null;
    }

    public Cat? Delete(Guid id)
    {
        if (_cats.Any(c => c.Id == id))
        {
            var catToDelete = _cats.FirstOrDefault(c => c.Id == id);
            _cats.Remove(catToDelete!);
            PersistInJsonFile();
            return catToDelete;
        }
        else
            return null;
    }
    
    private List<Cat>? FillWithCats()
    {
        var jsonCats = File.ReadAllText(_catsPath);
        return JsonSerializer.Deserialize<List<Cat>>(jsonCats);
    }

    private void PersistInJsonFile()
    {
        var jsonCats = JsonSerializer.Serialize(_cats);
        File.WriteAllText(_catsPath, jsonCats);
    }

    private void UpdateCat(Cat entity)
    {
        var catToUpdate = _cats.Find(c => c.Id == entity.Id);
        foreach (var property in catToUpdate!.GetType().GetProperties())
        {
            if(property.CanWrite)
                property.SetValue(catToUpdate, property.GetValue(entity));
        }
    }
}