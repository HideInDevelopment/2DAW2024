namespace Actvidad3.Presentation.Dtos;

#nullable disable
public class ColonyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int TelephoneNumber { get; set; }
    public int MobileNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public IReadOnlyCollection<CatDto> Cats { get; set; }
    public IReadOnlyCollection<PartnerDto> Partners { get; set; }
}