using Actividad3.Domain.Entities;
using Actividad3.Presentation.Dtos;
using AutoMapper;

namespace Actividad3.Application.Profiles;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<PartnerDto, Partner>().ReverseMap();
    }
}