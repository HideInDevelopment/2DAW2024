using Actividad3.Domain.Entities;

namespace Actividad3.Presentation.Dtos;

#nullable disable
public class ColonyDto : IDto, IMapToEntity<Colony>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int TelephoneNumber { get; set; }
    public int MobileNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public List<CatDto> CatItems { get; set; } = [];
    public List<PartnerDto> PartnerItems { get; set; } = [];
    
    public Colony ToEntity()
    {
        return new Colony()
        {
            Id = Id,
            Name = Name,
            Location = Location,
            TelephoneNumber = TelephoneNumber,
            MobileNumber = MobileNumber,
            Description = Description,
            Image = Image,
            CatItems = CatItems.Select(catItem => catItem.ToEntity()).ToList(),
        };
    }
}