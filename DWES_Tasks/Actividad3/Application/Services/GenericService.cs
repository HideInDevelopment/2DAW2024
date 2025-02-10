using Actividad3.Common.Validators;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Services;
using AutoMapper;

namespace Actividad3.Application.Services;

public class GenericService<TKey, TEntity, TDto> : IGenericService<TKey, TEntity, TDto>
    where TEntity : class
{
    private readonly IGenericRepository<TKey, TEntity> _repository;
    private readonly IMapper _mapper;

    public GenericService(IGenericRepository<TKey, TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto?> GetByIdAsync(TKey id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto?> AddAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var addedEntity = await _repository.AddAsync(entity);
        return EntityValidator.IsNullOrDefault(addedEntity) ? default : _mapper.Map<TDto>(addedEntity);
    }

    public async Task<TDto?> UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var updatedEntity = await _repository.UpdateAsync(entity);
        return EntityValidator.IsNullOrDefault(updatedEntity) ? default : _mapper.Map<TDto>(updatedEntity);
    }

    public async Task<TDto?> DeleteAsync(TKey id)
    {
        var deletedEntity = await _repository.DeleteAsync(id);
        return EntityValidator.IsNullOrDefault(deletedEntity) ? default : _mapper.Map<TDto>(deletedEntity);
    }
}