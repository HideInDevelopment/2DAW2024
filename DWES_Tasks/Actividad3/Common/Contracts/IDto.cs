using System.Text.Json.Serialization;
using Actividad3.Domain.Entities;

namespace Actividad3.Presentation.Dtos;

[JsonDerivedType(typeof(CatDto), "cat")]
[JsonDerivedType(typeof(ColonyDto), "colony")]
[JsonDerivedType(typeof(PartnerDto), "partner")]
public interface IDto {}