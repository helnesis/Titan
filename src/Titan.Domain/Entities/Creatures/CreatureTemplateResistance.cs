using System.Text.Json.Serialization;
using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateResistance : Entity
{
    
    [JsonPropertyName("school")]
    public SpellSchool School { get; init; }
    
    [JsonPropertyName("resistance")]
    public short Resistance { get; init; }
    
    [JsonConstructor]
    internal CreatureTemplateResistance(Identifier identifier, SpellSchool school, short resistance) : base(identifier)
        => (School, Resistance) = (school, resistance);
    
    public static ICreatureTemplateResistanceBuilder Builder => new CreatureTemplateResistanceBuilder();
}