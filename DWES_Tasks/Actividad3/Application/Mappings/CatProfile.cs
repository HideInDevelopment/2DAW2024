using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Profiles;

public class CatProfile : Profile
{
    public CatProfile()
    {
        CreateMap<CatDto, Cat>().ReverseMap();
        CreateMap<CatWithoutColonyItemDto, Cat>().ReverseMap();
    }
    
}