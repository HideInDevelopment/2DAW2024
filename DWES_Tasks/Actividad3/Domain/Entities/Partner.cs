using Actividad3.Presentation.Dtos;

namespace Actividad3.Domain.Entities;

#nullable disable
public class Partner : Entity<Guid>, IMapToDto<PartnerDto>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int TelephoneNumber { get; set; }
    public string Email { get; set; }
    public virtual List<ColonyPartner> ColonyPartnerItems { get; set; } = [];
    
    public PartnerDto ToDto()
    {
        return new PartnerDto()
        {
            Id = Id,
            Name = Name,
            Age = Age,
            TelephoneNumber = TelephoneNumber,
            Email = Email
        };
    }
}