using Actividad3.Presentation.Dtos;

namespace Actividad3.Domain.Entities;

#nullable disable
public class Colony : Entity<Guid>, IMapToDto<ColonyDto>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int TelephoneNumber { get; set; }
    public int MobileNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public virtual List<Cat> CatItems { get; set; } = [];
    public virtual List<ColonyPartner> ColonyPartnerItems { get; set; } = [];
    
    public ColonyDto ToDto()
    {
        return new ColonyDto()
        {
            Id = Id,
            Name = Name,
            Location = Location,
            TelephoneNumber = TelephoneNumber,
            MobileNumber = MobileNumber,
            Description = Description,
            Image = Image,
            CatItems = CatItems.Select(catItem => catItem.ToDto()).ToList(),
        };
    }
}