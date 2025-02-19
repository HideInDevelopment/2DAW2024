using Actividad3.Domain.Entities;

namespace Actividad3.Presentation.Dtos;

#nullable disable
public class PartnerDto : IDto, IMapToEntity<Partner>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int TelephoneNumber { get; set; }
    public string Email { get; set; }
    
    public Partner ToEntity()
    {
        return new Partner()
        {
            Id = Id,
            Name = Name,
            Age = Age,
            TelephoneNumber = TelephoneNumber,
            Email = Email,
        };
    }
}