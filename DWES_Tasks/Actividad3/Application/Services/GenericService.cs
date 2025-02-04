using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Services;
using AutoMapper;

namespace Actvidad3.Application.Services;

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

    public async Task<TDto> GetByIdAsync(TKey id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }

    public async Task AddAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(entity);
    }
}