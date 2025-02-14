using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Profiles;

public class ColonyProfile : Profile
{
    public ColonyProfile()
    {
        CreateMap<ColonyDto, Colony>().ReverseMap();
        CreateMap<ColonySDto, Colony>().ReverseMap();
    }
}