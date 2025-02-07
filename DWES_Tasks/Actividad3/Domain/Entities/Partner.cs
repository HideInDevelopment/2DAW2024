namespace Actvidad3.Domain.Entities;

#nullable disable
public class Partner
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int TelephoneNumber { get; set; }
    public string Email { get; set; }
    
    public IReadOnlyCollection<ColonyPartner> ColonyPartnerItems { get; set; }
}