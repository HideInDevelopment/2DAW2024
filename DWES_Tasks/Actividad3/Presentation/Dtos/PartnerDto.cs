namespace Actividad3.Presentation.Dtos;

#nullable disable
public class PartnerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int TelephoneNumber { get; set; }
    public string Email { get; set; }
    public IReadOnlyCollection<ColonyDto> ColonyItems { get; set; }
}