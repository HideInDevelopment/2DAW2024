namespace Actividad3.Presentation.Dtos;

public class PartnerSDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int TelephoneNumber { get; set; }
    public string Email { get; set; }
}