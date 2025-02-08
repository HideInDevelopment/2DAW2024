using Actvidad3.Domain.Contracts;

namespace Actvidad3.Domain.Entities;

#nullable disable
public class Colony : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int TelephoneNumber { get; set; }
    public int MobileNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    
    public IReadOnlyCollection<Cat> CatItems { get; set; }
    
    public IReadOnlyCollection<ColonyPartner> ColonyPartnerItems { get; set; }
}