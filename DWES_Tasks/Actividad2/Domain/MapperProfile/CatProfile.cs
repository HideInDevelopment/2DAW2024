using Actividad2.Domain.Dto;
using Actividad2.Domain.Entity;
using AutoMapper;

namespace Actividad2.Domain.MapperProfile;

public class CatProfile : Profile
{
    public CatProfile()
    {
        CreateMap<CatDto, Cat>()
            .ReverseMap()
            .ForMember(from => from.Id, to => to.MapFrom(source => source.Id))
            .ForMember(from => from.Name, to => to.MapFrom(source => source.Name))
            .ForMember(from => from.Age, to => to.MapFrom(source => source.Age))
            .ForMember(from => from.Race, to => to.MapFrom(source => source.Race))
            .ForMember(from => from.Weight, to => to.MapFrom(source => source.Weight))
            .ForMember(
                from => from.ColonyId,
                to => to.MapFrom(source => source.ColonyId)
            );
    }
}