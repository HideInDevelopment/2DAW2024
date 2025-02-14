using System.Text.Json.Serialization;
using Actividad3.Domain.Entities;

namespace Actividad3.Presentation.Dtos;

[JsonDerivedType(typeof(CatDto), "cat")]
[JsonDerivedType(typeof(CatWithoutColonyItemDto), "catWithoutColonyItem")]
[JsonDerivedType(typeof(ColonyDto), "colony")]
[JsonDerivedType(typeof(ColonySDto), "colonyS")]
[JsonDerivedType(typeof(ColonyWithCatIdsDto), "colonyWithCatIds")]
[JsonDerivedType(typeof(PartnerDto), "partner")]
[JsonDerivedType(typeof(PartnerSDto), "partnerS")]
public interface IDto {}