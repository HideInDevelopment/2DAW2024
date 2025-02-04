using Actvidad3.Domain.Entities;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Profiles;

public class ColonyProfile : Profile
{
    public ColonyProfile()
    {
        CreateMap<ColonyDto, Colony>().ReverseMap();
    }
}