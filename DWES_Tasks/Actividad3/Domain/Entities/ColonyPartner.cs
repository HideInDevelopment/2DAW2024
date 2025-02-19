using Actividad3.Presentation.Dtos;

namespace Actividad3.Domain.Entities;

#nullable disable
public class ColonyPartner : Entity<Guid>, IMapToDto<ColonyPartnerDto>  
{
    public Guid ColonyId { get; set; }
    public virtual Colony Colony { get; set; }

    public Guid PartnerId { get; set; }
    public virtual Partner Partner { get; set; }
    
    public ColonyPartnerDto ToDto()
    {
        return new ColonyPartnerDto()
        {
            Id = Id,
            ColonyId = ColonyId,
            PartnerId = PartnerId,
        };
    }
}