using Titan.Domain.Builders.Implementations.Creatures;
using Titan.Domain.Builders.Interfaces.Creatures;
using Titan.Domain.Entities.Base;
using Titan.Domain.Enums;

namespace Titan.Domain.Entities.Creatures;

public sealed record CreatureTemplateResistance : Entity
{
    public SpellSchool School { get; init; }
    public short Resistance { get; init; }
    
    internal CreatureTemplateResistance(Identifier identifier, SpellSchool school, short resistance) : base(identifier)
        => (School, Resistance) = (school, resistance);
    
    public static ICreatureTemplateResistanceBuilder Builder => new CreatureTemplateResistanceBuilder();
}