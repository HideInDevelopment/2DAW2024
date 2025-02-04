using Actvidad3.Domain.Entities;
using Actvidad3.Presentation.Dtos;
using AutoMapper;

namespace Actvidad3.Application.Profiles;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<PartnerDto, Partner>().ReverseMap();
    }
}