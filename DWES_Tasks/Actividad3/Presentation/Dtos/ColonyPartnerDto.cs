using Actividad3.Domain.Entities;

namespace Actividad3.Presentation.Dtos;

public class ColonyPartnerDto : IDto, IMapToEntity<ColonyPartner>
{
    public Guid Id { get; set; }
    public Guid ColonyId { get; set; }
    public Guid PartnerId { get; set; }
    
    public ColonyPartner ToEntity()
    {
        return new ColonyPartner()
        {
            Id = Id,
            ColonyId = ColonyId,
            PartnerId = PartnerId,
        };
    }
}