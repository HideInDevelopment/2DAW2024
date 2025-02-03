using Actividad2.Domain.Dto;
using Actividad2.Domain.Entity;
using Actividad2.Domain.Generic.Interface;
using AutoMapper;

namespace Actividad2.Domain.Service;

public class CatService(IEntityRepository<Guid, Cat> catRepository, IMapper mapper) : IEntityService<Guid, CatDto>
{
    public ICollection<CatDto>? Get() =>
        mapper.Map<ICollection<CatDto>>(catRepository.Get().ToList());

    public CatDto? Get(Guid id) => mapper.Map<CatDto>(catRepository.Get(id));

    public CatDto? Create(CatDto entity) =>
        mapper.Map<CatDto>(catRepository.Create(mapper.Map<Cat>(entity)));

    public CatDto? Update(CatDto entity) =>
        mapper.Map<CatDto>(catRepository.Update(mapper.Map<Cat>(entity)));

    public CatDto? Delete(Guid id) => mapper.Map<CatDto>(catRepository.Delete(id));
}