namespace Actvidad3.Domain.Entities;

#nullable disable
public class Colony
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int TelephoneNumber { get; set; }
    public int MobileNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public IReadOnlyCollection<Cat> CatItems { get; set; }
    public IReadOnlyCollection<Partner> PartnerItems { get; set; }
}