namespace Actividad3.Presentation.Dtos;

public class ColonySDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int TelephoneNumber { get; set; }
    public int MobileNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    
    public List<CatWithoutColonyItemDto> CatItems { get; set; } = [];
}